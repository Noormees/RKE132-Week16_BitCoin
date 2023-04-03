


using BitCoin;
using Newtonsoft.Json;
using System.Net;

BitCoinrate bitcoin = GetRates();

Console.WriteLine($"Current BitCoin rate is {bitcoin.bpi.EUR.rate_float} {bitcoin.bpi.EUR.code}");

static BitCoinrate GetRates()
{
    string url = "https://api.coindesk.com/v1/bpi/currentprice.json";

    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    request.Method = "GET";

    var webResponse = request.GetResponse();        //vastus, mis me saame katte
    var webStream = webResponse.GetResponseStream();      //teeb yhenduse lahti

    BitCoinrate bitcoinRate;        //pamene vahemalusse kohta, kuhu andmed serverist salvestatakse

    using (var responseReader = new StreamReader(webStream)) //teeme yhenduse lahti
    {
        var response = responseReader.ReadToEnd();        //votame andmed vastu
        bitcoinRate = JsonConvert.DeserializeObject<BitCoinrate>(response);     //konverteerime vastuse, anname classi BitCoinrate
    }


    return bitcoinRate;
}
