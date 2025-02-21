using CarBook.Dto.FeatureDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarFeatureDtos
{
    public class CarFeatureViewModel
    {
        public List<ResultFeatureDto> Features { get; set; } 
        public CreateCarFeatureDto CreateCarFeature { get; set; }
    }
}
