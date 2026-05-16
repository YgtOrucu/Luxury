namespace Luxury.BusinessLayer.Models.RapidApi
{
    public class TopFiveDestinationsResponse
    {
        public Destination[] destinations { get; set; }
        public City[] cities { get; set; }
    }

    public class Destination
    {
        public string name { get; set; }
        public string imageUrl { get; set; }
        public float averagePrice { get; set; }
        public int hotelCount { get; set; }
    }

    public class City
    {
        public string name { get; set; }
        public string imageUrl { get; set; }
        public float averagePrice { get; set; }
        public int hotelCount { get; set; }
    }




    //DESTİNATION
    //name:"Punta Cana"
    //imageUrl:"https://imgcy.trivago.com/c_fill,d_dummy.jpeg,e_sharpen:60,f_auto,h_258,q_auto,w_258/categoryimages/73/65/73652_v67.jpeg"
    //averagePrice:311.79825846
    //hotelCount:1296

}

