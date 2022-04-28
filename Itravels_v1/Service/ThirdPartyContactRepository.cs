using AutoMapper;
using Itravels_v1.DAL;
using Itravels_v1.Model.ThirdPartyContact;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itravels_v1.Service
{
    public class ThirdPartyContactRepository
    {
        public async Task<string> AddNewThirdpartyContactAsync(ThirdPartyContactModel thmodel)
        {
            try
            {
                using (Itravels_v1Context DBContext = new Itravels_v1Context())
                {
                    if (thmodel == null)
                    {
                        return "1";
                    }

                    ThirdPartyContact thcontact = new ThirdPartyContact();

                    var config = new MapperConfiguration(
                       m => m.CreateMap<ThirdPartyContactModel, ThirdPartyContact>()
                       );

                    var mapper = new Mapper(config);

                    thcontact = mapper.Map<ThirdPartyContactModel, ThirdPartyContact>(thmodel);


                    await DBContext.ThirdPartyContact.AddAsync(thcontact);
                    await DBContext.SaveChangesAsync();
                    return "0";
                }


            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        public async Task<ThirdPartyContact> GetThirdpartyContactById(int id)
        {
            try
            {
                ThirdPartyContact th = new ThirdPartyContact();

                using (Itravels_v1Context context = new Itravels_v1Context())
                {

                    th = await context.ThirdPartyContact.FirstOrDefaultAsync(c => c.ContactId == id);

                }

                return th;

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<ThirdPartyContact>> GetAllContactsbyUserIdAsync(int id)
        {
            try
            {
                List<ThirdPartyContact> ths = new List<ThirdPartyContact>();

                using (Itravels_v1Context context = new Itravels_v1Context())
                {

                    ths = await context.ThirdPartyContact.Where(c => c.UserId == id).ToListAsync();

                }

                return ths;

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<string> UpdateContactAsync(ThirdPartyContactUpdateModel mdl)
        {
            try
            {
                using (Itravels_v1Context DBContext = new Itravels_v1Context())
                {
                    if (mdl == null)
                    {
                        return "1";
                    }

                    ThirdPartyContact th = new ThirdPartyContact();

                    th = await GetThirdpartyContactById(mdl.ContactId);

                    if (th == null)
                    {
                        return "1";
                    }

                    var config = new MapperConfiguration(
                       m => m.CreateMap<ThirdPartyContactUpdateModel, ThirdPartyContact>()
                       );

                    var mapper = new Mapper(config);

                    th = mapper.Map<ThirdPartyContactUpdateModel, ThirdPartyContact>(mdl);


                    // Update entity in DbSet
                    DBContext.ThirdPartyContact.Update(th);

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
