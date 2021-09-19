

using System.ComponentModel;

namespace Pocker.Infrastructure
{
	public static class DescriptionHelper
	{
		public static string Get(object item)
		{
			return AttributeHelper<DescriptionAttribute>.GetPropertyAttr(item, item.ToString())?.Description;
		}
	}
}
