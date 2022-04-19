using AutoMapper;
using Itravels_v1.DAL;
using Itravels_v1.Model.Inquiry;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itravels_v1.Service
{
    public class InquiryRepository
    {
        public async Task<string> AddNewInquiryAsync(InquiryModel inquiryModel)
        {
            try
            {
                using (Itravels_v1Context DBContext = new Itravels_v1Context())
                {
                    if (inquiryModel == null)
                    {
                        return "1";
                    }

                    Inquiry inquiry = new Inquiry();

                    var config = new MapperConfiguration(
                       m => m.CreateMap<InquiryModel, Inquiry>()
                       );

                    var mapper = new Mapper(config);

                    inquiry = mapper.Map<InquiryModel, Inquiry>(inquiryModel);


                    await DBContext.Inquiry.AddAsync(inquiry);
                    await DBContext.SaveChangesAsync();
                    return "0";
                }


            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        public async Task<Inquiry> GetInquiryAsync(int id)
        {
            try
            {
                Inquiry inquiry = new Inquiry();

                using (Itravels_v1Context context = new Itravels_v1Context())
                {

                    inquiry = await context.Inquiry.FirstOrDefaultAsync(c => c.InquiryId == id);
                    
                }

                return inquiry;

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<Inquiry>> GetAllInquiriesbyBaggageIdAsync(int id)
        {
            try
            {
                List<Inquiry> inquiry = new List<Inquiry>();

                using (Itravels_v1Context context = new Itravels_v1Context())
                {

                    inquiry = await context.Inquiry.Where(c => c.BaggageId == id).ToListAsync();

                }

                return inquiry;

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<string> UpdateInquiryAsync(InquiryUpdateModel inquiryModel)
        {
            try
            {
                using (Itravels_v1Context DBContext = new Itravels_v1Context())
                {
                    if (inquiryModel == null)
                    {
                        return "1";
                    }

                    Inquiry inquiry = new Inquiry();

                    inquiry = await GetInquiryAsync(inquiryModel.InquiryId);

                    if(inquiry == null)
                    {
                        return "1";
                    }

                    var config = new MapperConfiguration(
                       m => m.CreateMap<InquiryUpdateModel, Inquiry>()
                       );

                    var mapper = new Mapper(config);

                    inquiry = mapper.Map<InquiryUpdateModel, Inquiry>(inquiryModel);


                    // Update entity in DbSet
                    DBContext.Inquiry.Update(inquiry);

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
