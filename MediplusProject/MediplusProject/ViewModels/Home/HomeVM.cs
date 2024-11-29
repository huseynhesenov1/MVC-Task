using MediplusProject.Models;

namespace MediplusProject.ViewModels.Home
{
	public class HomeVM
	{
		public IEnumerable<SliderItem>? sliderItems { get; set; }
		public IEnumerable<Coursel>? coursels { get; set; }
		public IEnumerable<HomeCard>? homeCards { get; set; }
		public IEnumerable<Scores>? scores { get; set; }

	}
}
