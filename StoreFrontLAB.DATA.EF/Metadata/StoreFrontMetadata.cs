using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StoreFrontLAB.DATA.EF
{


    #region CandyType Metadata

    public class CandyTypeMetadata
    {


        //public int ID { get; set; }

        [StringLength(50, ErrorMessage = "* Candy Type Name must be 50 characters or less.")]
        [Required(ErrorMessage = "* Candy Type Name is required")]
        [Display(Name = "Candy Type")]
        public string Name { get; set; }

        [UIHint("MultilineText")]
        [DisplayFormat(NullDisplayText = "[N/A]")]
        public string Description { get; set; }


    }

    [MetadataType(typeof(CandyTypeMetadata))]
    public partial class CandyType
    {

    }

    #endregion

    #region Category Metadata

    public class CategoryMetadata
    {


        //public int ID { get; set; }

        [StringLength(50, ErrorMessage = "* Category Name must be 50 characters or less.")]
        [Required(ErrorMessage = "* Category Name is required")]
        [Display(Name= "Category Name")]
        public string Name { get; set; }

        [UIHint("MultilineText")]
        [DisplayFormat(NullDisplayText = "[N/A]")]
        public string Description { get; set; }


    }

    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category
    {

    }

    #endregion

    #region Manufacturer Metadata

    public class ManufacturerMetadata
    {


        //public int ID { get; set; }

        [StringLength(50, ErrorMessage = "* Manufacturer Name must be 50 characters or less.")]
        [Required(ErrorMessage = "* Manufacturer Name is required")]
        [Display(Name = "Manufacturer Name")]
        public string Name { get; set; }

        [UIHint("MultilineText")]
        [DisplayFormat(NullDisplayText = "[N/A]")]
        public string Description { get; set; }


    }

    [MetadataType(typeof(ManufacturerMetadata))]
    public partial class Manufacturer
    {

    }

    #endregion

    #region Product Metadata

    public class ProductMetadata
    {


        //public int ID { get; set; }

        [Display(Name = "Product")]
        [Required(ErrorMessage = "* Product Name is Required.")]
        [StringLength(25, ErrorMessage = "* Product Name must be 25 characters or less.")]
        public string Name { get; set; }

        [UIHint("MultilineText")]
        [DisplayFormat(NullDisplayText = "[N/A]")]
        public string Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "* Price must be a valid number (0+)")]
        [DisplayFormat(DataFormatString = "{0:c}", NullDisplayText = "[N/A]")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "* Category ID is required")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "* Manufacturer ID is required")]
        public int ManufacturerID { get; set; }

        [Required(ErrorMessage = "* Product Status ID is required")]
        public int ProductStatusID { get; set; }

        [Required(ErrorMessage = "* Candy Type ID is required")]
        public int CandyTypeID { get; set; }

        [Display(Name = "Photo")]
        public string ProductImage { get; set; }


    }

    [MetadataType(typeof(ProductMetadata))]
    public partial class Product
    {

    }

    #endregion

    #region Product Status Metadata

    public class ProductStatusMetadata
    {


        //public int ID { get; set; }

        [StringLength(50, ErrorMessage = "* Product Status Name must be 50 characters or less.")]
        [Required(ErrorMessage = "* Product Status Name is required")]
        [Display(Name = "Product Status")]
        public string Name { get; set; }

        [UIHint("MultilineText")]
        [DisplayFormat(NullDisplayText = "[N/A]")]
        public string Description { get; set; }


    }

    [MetadataType(typeof(ProductStatusMetadata))]
    public partial class ProductStatus
    {

    }

    #endregion


}
