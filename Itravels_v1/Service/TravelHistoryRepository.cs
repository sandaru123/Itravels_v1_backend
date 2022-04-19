using AutoMapper;
using Itravels_v1.DAL;
using Itravels_v1.Model.TravelHistory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itravels_v1.Service
{
    public class TravelHistoryRepository
    {
        public async Task<string> AddNewTravelHistoryAsync(TravelHistoryModel model)
        {
            try
            {
                using (Itravels_v1Context DBContext = new Itravels_v1Context())
                {
                    if (model == null)
                    {
                        return "1";
                    }

                    TravelHistory travelHistory = new TravelHistory();

                    var config = new MapperConfiguration(
                       m => m.CreateMap<TravelHistoryModel, TravelHistory>()
                       );

                    var mapper = new Mapper(config);

                    travelHistory = mapper.Map<TravelHistoryModel, TravelHistory>(model);


                    await DBContext.TravelHistory.AddAsync(travelHistory);
                    await DBContext.SaveChangesAsync();
                    return "0";
                }


            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public async Task<List<TravelHistory>> GetHistoryByUserId(int id)
        {
            try
            {
                using (Itravels_v1Context DBContext = new Itravels_v1Context())
                {
                    List<TravelHistory> th = new List<TravelHistory>();

                    th = await DBContext.TravelHistory.Where(c => c.UserId == id).ToListAsync();


                    return th;
                }


            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
