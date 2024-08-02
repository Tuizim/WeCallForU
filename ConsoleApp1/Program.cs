using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static async Task Main(string[] args)
        {
            WeCallForU.WeCallForU api = new WeCallForU.WeCallForU();
            WeCallForU.Context context = new WeCallForU.Context();

            context.Body = @"<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:ws='http://ws.travelsuite.com.br'>
   <soapenv:Header/>
   <soapenv:Body>
      <ws:GetPnrGroupDetail>
         <!--Optional:-->
         <ws:pnrGroup>R9L9J8B579</ws:pnrGroup>
      </ws:GetPnrGroupDetail>
   </soapenv:Body>
</soapenv:Envelope>";
            context.RequestType= WeCallForU.Context.Type.Post;
            context.Url= "http://webservices.travelexplorer.com.br/reservation/resservice/wsReservation.asmx";
            string teste = await api.Execute(context);
        }
    }
}
