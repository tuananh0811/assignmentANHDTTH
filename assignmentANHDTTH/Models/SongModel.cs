using assignmentANHDTTH.Entities;
using assignmentANHDTTH.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentANHDTTH.Models
{
    public class SongModel
    {
        SongService songService = new SongService();
        public async Task<List<MySong>> GetAll()
        {
            List<MySong> list = await songService.GetAll();
            return list;
        }
    }
}
