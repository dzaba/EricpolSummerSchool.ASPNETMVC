using System;
using System.Threading.Tasks;

namespace XamarinPlayoffsSample.Interfaces
{
	public interface INavigable
	{
		Task OnNavigateTo(object navigationParameter);
	}
}