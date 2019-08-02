using ComcastMoviesApplication.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastMovieApplication.Tests
{
    [TestClass]
    public class ValidationHelperTest
    {
        [TestMethod]
        public void TestValidationIsValidGuid()
        {
            ValidationHelper vHelper = new ValidationHelper();
            Guid? guid;
            Assert.IsFalse(vHelper.IsValidGuid("abc", out guid));
            Assert.IsTrue(vHelper.IsValidGuid("6685CBAF-E56C-4B18-A909-7E806FF5B256", out guid));
        }

        [TestMethod]
        public void TestValidationIsValidEditMovieRatingRequest()
        {
            ValidationHelper vHelper = new ValidationHelper();
            
            Assert.IsFalse(vHelper.IsValidEditMovieRatingRequest(null, null,null));
            Assert.IsFalse(vHelper.IsValidEditMovieRatingRequest("6685CBAF-E56C-4B18-A909-7E806FF5B256", null,null));
            Assert.IsFalse(vHelper.IsValidEditMovieRatingRequest("6685CBAF-E56C-4B18-A909-7E806FF5B256", "6685CBAF-E56C-4B18-A909-7E806FF5B256", null));
            Assert.IsFalse(vHelper.IsValidEditMovieRatingRequest("6685CBAF-E56C-4B18-A909-7E806FF5B256", "6685CBAF-E56C-4B18-A909-7E806FF5B256", "0"));
            Assert.IsFalse(vHelper.IsValidEditMovieRatingRequest("6685CBAF-E56C-4B18-A909-7E806FF5B256", "6685CBAF-E56C-4B18-A909-7E806FF5B256", "6"));
            Assert.IsTrue(vHelper.IsValidEditMovieRatingRequest("6685CBAF-E56C-4B18-A909-7E806FF5B256", "6685CBAF-E56C-4B18-A909-7E806FF5B256", "1"));
            Assert.IsTrue(vHelper.IsValidEditMovieRatingRequest("6685CBAF-E56C-4B18-A909-7E806FF5B256", "6685CBAF-E56C-4B18-A909-7E806FF5B256", "5"));
            Assert.IsTrue(vHelper.IsValidEditMovieRatingRequest("6685CBAF-E56C-4B18-A909-7E806FF5B256", "6685CBAF-E56C-4B18-A909-7E806FF5B256", "4"));
        }

        [TestMethod]
        public void TestValidationIsValidFindMovieRequest()
        {
            ValidationHelper vHelper = new ValidationHelper();

            Assert.IsFalse(vHelper.IsValidEditMovieRatingRequest(null, null, null));
            Assert.IsTrue(vHelper.IsValidFindMovieRequest("Lion", null, null));
            Assert.IsTrue(vHelper.IsValidFindMovieRequest("Lion", "9999", null));
            Assert.IsTrue(vHelper.IsValidFindMovieRequest("Lion", "9999", "Animation"));
            Assert.IsFalse(vHelper.IsValidFindMovieRequest("Lion", "abc", "Animation"));



        }

    }
}
