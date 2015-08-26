using HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Infrastructure.Repository
{
    public interface IHRRepository
    {
        IEnumerable<InfoType> GetAllInfoType { get; }
        IEnumerable<Image> GetAllImage { get; }
        void SaveInfoType(InfoType infoType);
    }
}
