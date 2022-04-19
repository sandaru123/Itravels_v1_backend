using AutoMapper;
using Itravels_v1.DAL;
using Itravels_v1.Model.Baggage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itravels_v1.Service
{
    public class BaggageRepository
    {
        public async Task<string> CreateBaggageAsync(BaggageModel baggageModel)
        {
            try
            {
                using (Itravels_v1Context DBContext = new Itravels_v1Context())
                {
                    if(baggageModel == null)
                    {
                        return "1";
                    }

                    Baggage baggage = new Baggage();

                    var config = new MapperConfiguration(
                       m => m.CreateMap<BaggageModel, Baggage>()
                       );

                    var mapper = new Mapper(config);

                    baggage = mapper.Map<BaggageModel, Baggage>(baggageModel);


                    await DBContext.Baggage.AddAsync(baggage);
                    await DBContext.SaveChangesAsync();
                    return "0";
                }


            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        public async Task<Baggage> GetBaggageById(int id)
        {
            try
            {
                using (Itravels_v1Context DBContext = new Itravels_v1Context())
                {
                    Baggage baggage = new Baggage();

                    baggage = await DBContext.Baggage.FirstOrDefaultAsync(c => c.BaggageId == id);


                    return baggage;
                }


            }
            catch (Exception ex) { 
                return null;
            }

        }


        public async Task<List<Baggage>> GetBaggagesByUserId(int id)
        {
            try
            {
                using (Itravels_v1Context DBContext = new Itravels_v1Context())
                {
                    List<Baggage> baggages = new List<Baggage>();

                    baggages = await DBContext.Baggage.Where(c => c.UserId == id).ToListAsync();


                    return baggages;
                }


            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
