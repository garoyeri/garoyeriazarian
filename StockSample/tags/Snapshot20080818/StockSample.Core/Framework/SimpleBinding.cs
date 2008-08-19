using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace StockSample.Core.Framework
{
	public class SimpleBinding
	{
		public static SimpleBinding Bind(object object1, string property1,
			object object2, string property2, ISynchronizeInvoke affinity)
		{
			return new SimpleBinding(object1, property1, object2, property2, affinity);
		}

		object _object1, _object2;
		PropertyInfo _prop1, _prop2;

		MethodInfo _prop1get, _prop1set;
		MethodInfo _prop2get, _prop2set;

		ISynchronizeInvoke _affinity;

		private SimpleBinding()
		{
		}

		public SimpleBinding(object object1, string property1, object object2, string property2)
			: this(object1, property1, object2, property2, null)
		{
		}

		public SimpleBinding(object object1, string property1, object object2, string property2, ISynchronizeInvoke affinity)
		{
			if (object1 == null) throw new ArgumentNullException("object1");
			if (property1 == null) throw new ArgumentNullException("property1");
			if (object2 == null) throw new ArgumentNullException("object2");
			if (property2 == null) throw new ArgumentNullException("property2");

			_affinity = affinity;

			// get the property informations
			_object1 = object1;
			_prop1 = _object1.GetType().GetProperty(property1);
			if (_prop1 != null)
			{
				_prop1get = _prop1.GetGetMethod();
				_prop1set = _prop1.GetSetMethod();
			}

			_object2 = object2;
			_prop2 = _object2.GetType().GetProperty(property2);
			if (_prop2 != null)
			{
				_prop2get = _prop2.GetGetMethod();
				_prop2set = _prop2.GetSetMethod();
			}

			// figure out the trigger for property 1
			DetermineTrigger(_object1, _prop1);
			DetermineTrigger(_object2, _prop2);

			// make sure these are synced right now
			OnProperty1Changed();
		}


		protected void DetermineTrigger(object obj, PropertyInfo prop)
		{
			if (TryNotifyPropertyChangedTrigger(obj, prop)) return;
			if (TryPropertyNameChangedEventTrigger(obj, prop)) return;
		}


		protected bool TryNotifyPropertyChangedTrigger(object obj, PropertyInfo prop)
		{
			INotifyPropertyChanged notify = obj as INotifyPropertyChanged;
			if (notify == null) return false;

			notify.PropertyChanged += new PropertyChangedEventHandler(Object_PropertyChanged);
			return true;
		}

		private void Object_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (sender == _object1 && e.PropertyName == _prop1.Name) OnProperty1Changed();
			else if (sender == _object2 && e.PropertyName == _prop2.Name) OnProperty2Changed();
		}

		protected bool TryPropertyNameChangedEventTrigger(object obj, PropertyInfo prop)
		{
			EventInfo evt = obj.GetType().GetEvent(prop.Name + "Changed");
			if (evt == null) return false;

			evt.AddEventHandler(obj, new EventHandler(Object_PropertyChanged));
			return true;
		}

		private void Object_PropertyChanged(object sender, EventArgs e)
		{
			if (sender == _object1) OnProperty1Changed();
			else if (sender == _object2) OnProperty2Changed();
		}

		protected virtual void OnProperty1Changed()
		{
			if (_prop1get == null) return;
			if (_prop2set == null) return;

			if (_affinity != null && _affinity.InvokeRequired)
			{
				_affinity.BeginInvoke(new Action(OnProperty1Changed), new object[0]);
				return;
			}

			object value = _prop1get.Invoke(_object1, new object[0]);

			_prop2set.Invoke(_object2, new object[] { value });
		}

		protected virtual void OnProperty2Changed()
		{
			if (_prop2get == null) return;
			if (_prop1set == null) return;

			if (_affinity != null && _affinity.InvokeRequired)
			{
				_affinity.BeginInvoke(new Action(OnProperty2Changed), new object[0]);
				return;
			}

			object value = _prop2get.Invoke(_object2, new object[0]);

			_prop1set.Invoke(_object1, new object[] { value });
		}
	}
}
