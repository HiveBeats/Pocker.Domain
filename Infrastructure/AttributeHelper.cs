using System.Linq;

namespace Pocker.Infrastructure
{
	public static class AttributeHelper<T>
		where T : System.Attribute
	{
		#region Public methods

		public static T GetAttr(object item)
		{
			if (item == null)
				return null;

			var type = item.GetType();
			var attr = type.GetCustomAttributes(typeof(T), true).FirstOrDefault();

			return attr as T;
		}

		public static T GetPropertyAttr(object item, string name)
		{
			if (item == null || name == null)
				return null;

			var type = item.GetType();
			var attr = type.GetProperty(name)?.GetCustomAttributes(typeof(T), true).FirstOrDefault();

			if (attr == null)
				attr = type.GetField(name)?.GetCustomAttributes(typeof(T), true).FirstOrDefault();

			return attr as T;
		}

		#endregion
	}
}
