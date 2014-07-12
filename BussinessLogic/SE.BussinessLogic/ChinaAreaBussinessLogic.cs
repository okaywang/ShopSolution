using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE.BussinessLogic
{
    public class ChinaAreaBussinessLogic
    {
        private EfRepository<ChinaProvince> _areaProviceRepository;
        public ChinaAreaBussinessLogic(EfRepository<ChinaProvince> areaProviceRepository)
        {
            _areaProviceRepository = areaProviceRepository;
        }

        public ChinaProvince[] GetProvinces()
        {
            return _areaProviceRepository.Table.ToArray();
        }
    }
}
