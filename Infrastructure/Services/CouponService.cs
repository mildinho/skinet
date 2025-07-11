﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Core.Entities;
//using Core.Interfaces;
//using Microsoft.Extensions.Configuration;

//namespace Infrastructure.Services
//{
//    public class CouponService : ICouponService
//    {
//        public CouponService(IConfiguration config)
//        {
//            StripeConfiguration.ApiKey = config["StripeSettings:SecretKey"];
//        }

//        public async Task<AppCoupon?> GetCouponFromPromoCode(string code)
//        {
//            var promotionService = new PromotionCodeService();

//            var options = new PromotionCodeListOptions
//            {
//                Code = code
//            };

//            var promotionCodes = await promotionService.ListAsync(options);

//            var promotionCode = promotionCodes.FirstOrDefault();

//            if (promotionCode != null && promotionCode.Coupon != null)
//            {
//                return new AppCoupon
//                {
//                    Name = promotionCode.Coupon.Name,
//                    AmountOff = promotionCode.Coupon.AmountOff,
//                    PercentOff = promotionCode.Coupon.PercentOff,
//                    CouponId = promotionCode.Coupon.Id,
//                    PromotionCode = promotionCode.Code
//                };
//            }

//            return null;
//        }
//    }
//}
