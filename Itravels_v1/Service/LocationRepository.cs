using AutoMapper;
using Itravels_v1.DAL;
using Itravels_v1.Model.Location;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itravels_v1.Service
{
    public class LocationRepository
    {
        public async Task<string> AddnewLocationRecordAsync(LocationModel model)
        {
            try
            {
                using (Itravels_v1Context DBContext = new Itravels_v1Context())
                {
                    if (model == null)
                    {
                        return "1";
                    }

                    Location location = new Location();

                    var config = new MapperConfiguration(
                       m => m.CreateMap<LocationModel, Location>()
                       );

                    var mapper = new Mapper(config);

                    location = mapper.Map<LocationModel, Location>(model);


                    await DBContext.Location.AddAsync(location);
                    await DBContext.SaveChangesAsync();
                    return "0";
                }


            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        public async Task<Location> GetLocationByBaggageIdAsync(int id)
        {
            try
            {
               
                using (Itravels_v1Context context = new Itravels_v1Context())
                {

                    Location location = await context.Location.FirstOrDefaultAsync(c => c.BaggageId == id);

                    return location;

                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<string> UpdateInquiryByBaggageIdAsync(LocationUpdateModel model)
        {
            try
            {
                using (Itravels_v1Context DBContext = new Itravels_v1Context())
                {
                    if (model == null)
                    {
                        return "1";
                    }

                   

                    Location loc = await GetLocationByBaggageIdAsync(model.BaggageId);

                    if (loc == null)
                    {
                        return "1";
                    }

                    var config = new MapperConfiguration(
                       m => m.CreateMap<LocationUpdateModel, Location>()
                       );

                    var mapper = new Mapper(config);

                    loc = mapper.Map<LocationUpdateModel, Location>(model);


                    // Update entity in DbSet
                    DBContext.Location.Update(loc);

                    // Save changes in database
                    await DBContext.SaveChangesAsync();

                    return "0";
                }


            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

    }
}
