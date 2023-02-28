using AutoMapper;
using QuestPDF.Fluent;
using QuestPDF.Previewer;
using Generation_Documents.Entities;
using Generation_Documents.Models;
using Generation_Documents.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Xml.Linq;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Security.Cryptography.X509Certificates;

namespace Generation_Documents.Controllers
{
    [ApiController]
    [Route("API/generate")]
    public class GenerateController : ControllerBase
    {
        
        private readonly IMapper _Mapper;
        private readonly IDataRepository _DataRepository;
        //const int MaxPersonPageSize = 20;

        // we make the constructor to inisiate the filds that are used for logs and services
        public GenerateController(IDataRepository DataRepository, IMapper mapper)
        {
            _Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _DataRepository = DataRepository ?? throw new ArgumentNullException(nameof(DataRepository));
        }



        //[HttpGet(Name = "GetListOfClinet")]
        ////[Authorize]

        //public async Task<ActionResult<IEnumerable<ClientDTO>>> GetClients()
        //{
        //    var Clinets = await _DataRepository.GetListOfClientsAsync();
        //    return Ok(_Mapper.Map<IEnumerable<ClientDTO>>(Clinets));
        //}


        //[HttpGet(Name = "GetClinet")]
        ////[Authorize]

        //public async Task<ActionResult<ClientDTO>> GetClient(string? name, string? searchQ)
        //{
        //    var Clients = await _DataRepository.GetClientAsync( name,searchQ);

        //    if (Clients == null)
        //    {
        //        return NotFound();
        //    }
            
        //        return Ok(_Mapper.Map<ClientDTO>(Clients));
        //}





        //[HttpPost]
        ////[Authorize]
        //public async Task<ActionResult<ClientDTO>> AddClinet(ClientAddDTO ClientADD)
        //{



        //    var finalvalue = _Mapper.Map<Entities.Client>(ClientADD);

        //    await _DataRepository.AddAClientAsync(finalvalue);
        //    await _DataRepository.SaveChangesAsync();

        //    var CreatedClient = _Mapper.Map<ClientDTO>(finalvalue);

        //    return CreatedAtRoute("GetClinet",
        //        new
        //        {
        //            Id = CreatedClient.IdClient
        //        },
        //        CreatedClient);
        //}


        [HttpPost]
        public ActionResult<SalesInvoiceDTO>GenerateSalesI(RecivedDataDTO recivedDataDTO,int total,int btw)
        {
            var BTW = (float)21.00;
            var Total = (float)960.00;
            
           // var clientfromRD = _Mapper.Map<Entities.Client>(recivedDataDTO);
            QuestPDF.Fluent.Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Margin((float)1.5,Unit.Centimetre);
                    page.MarginRight(2, Unit.Centimetre);
                    page.MarginLeft(2, Unit.Centimetre);

                    page.Header().Element(HeaderFunction);
                    
                    page.Content().Column(column =>
                    {




                        column.Item().BorderBottom(1).Height(20).AlignCenter()
                              .Text("Sales invoice").FontSize(12);

                        column.Item().Row(row =>
                        {
                            row.RelativeColumn((float)1.2).Column(column =>
                            {
                                column.Item().PaddingTop(20).Text("Factuuurnummer").FontSize(10);
                                column.Item().Text("Debiteurnummer").FontSize(10);
                                column.Item().Text("Factuurdatum").FontSize(10);
                                column.Item().Text("Werknummer").FontSize(10);
                                column.Item().Text("Assigenementnummer CED").FontSize(10);
                                column.Item().Text("NeeSchadedatum").FontSize(10);
                                column.Item().Text("Hersteldatum").FontSize(10);
                                column.Item().Text("Schadeoorzaak").FontSize(10);
                            });


                            row.RelativeColumn(1).Column(column =>
                            {
                                column.Item().PaddingTop(20).Text(": 94200051").FontSize(10);
                                column.Item().Text(": 123354656").FontSize(10);
                                column.Item().Text(": 06-07-2022").FontSize(10);
                                column.Item().Text(": 34Q22108850 - 01 - 01").FontSize(10);
                                column.Item().Text(": 34Q22108850 - 01").FontSize(10);
                                column.Item().Text(": 06-07-2022").FontSize(10);
                                column.Item().Text(": 06-07-2022").FontSize(10);
                                column.Item().Text(": Menselijke acties").FontSize(10);
                            });

                            row.RelativeColumn(1).Column(column =>
                            {
                                column.Item().PaddingTop(20).Text("Verzekerde").FontSize(10);
                                column.Item().Text("Woonplaats").FontSize(10);
                                column.Item().Text("Polisnummer").FontSize(10);
                                column.Item().Text("Eigen risico").FontSize(10);
                                column.Item().Text("BTW verrekenbaar").FontSize(10);
                                column.Item().Text("Referentienummer").FontSize(10);
                                column.Item().Text("Schadenummer").FontSize(10);
                            });

                            row.RelativeColumn(1).Column(column =>
                            {
                                column.Item().PaddingTop(20).Text(": najoua5 test5").FontSize(10);
                                column.Item().Text(": VLAARDINGEN").FontSize(10);
                                column.Item().Text(": 35").FontSize(10);
                                column.Item().Text(": 0,00").FontSize(10);
                                column.Item().Text(": Nee").FontSize(10);
                                column.Item().Text(":").FontSize(10);
                                column.Item().Text(":25").FontSize(10);
                            });
                        });

                        column.Item()
                        .PaddingTop((float)0.5,Unit.Centimetre)
                        .BorderBottom(1)
                        .PaddingBottom((float)0.5, Unit.Centimetre).Row(row => 
                        {
                            row.ConstantColumn(140).Column(column =>
                            {
                                column.Item().Text("General").FontSize(10);
                            });
                            row.RelativeColumn().Column(column =>
                            {
                                column.Item().Text(": test1 / test2 / test3").FontSize(10);
                            });

                        });
                        column.Item()
                        .PaddingTop((float)0.1, Unit.Centimetre)
                        .BorderBottom(1)
                        .PaddingBottom((float)0.1, Unit.Centimetre).Row(row =>
                        {
                            row.ConstantColumn(200).Column(column =>
                            {
                                column.Item().AlignLeft().Text("Omschrijving").FontSize(10);
                            });
                            row.RelativeColumn().Column(column =>
                            {
                                column.Item().AlignCenter().Text("Aantal").FontSize(10);
                            });
                            row.RelativeColumn().AlignCenter().Column(column =>
                            {
                                column.Item().AlignCenter().Text("Prijs").FontSize(10);
                            });
                            row.RelativeColumn().Column(column =>
                            {
                                column.Item().AlignCenter().Text("Netto Bedrag").FontSize(10);
                            });
                            row.RelativeColumn().Column(column =>
                            {
                                column.Item().AlignCenter().Text("BTW%").FontSize(10);
                            });

                        });
                       
                        column.Item()
                       .PaddingTop((float)0.1, Unit.Centimetre)
                       .PaddingBottom((float)0.1, Unit.Centimetre)
                       .Row(row =>
                       {
                           row.RelativeItem().Column(column =>
                           {
                               column.Item().Text("Inboedel").FontSize(10);
                           });
                       });
                       
                       column.Item()
                      .PaddingTop((float)0.1, Unit.Centimetre)
                      .PaddingBottom((float)0.1, Unit.Centimetre).Row(row =>
                      {
                          row.ConstantColumn(200).Column(column =>
                          {
                              column.Item().Text("Toeslag spoedopdracht (arbeid)").FontSize(10);
                          });
                          row.RelativeColumn().Column(column =>
                          {
                              column.Item().AlignCenter().Text("3 post").FontSize(10);
                          });
                          row.RelativeColumn().Column(column =>
                          {
                              column.Item().AlignCenter().Text("€320,00").FontSize(10);
                          });
                          row.RelativeColumn().Column(column =>
                          {
                              column.Item().AlignCenter().Text("€"+Total).FontSize(10);
                          });
                          row.RelativeColumn().Column(column =>
                          {
                              column.Item().AlignCenter().Text(BTW+"%").FontSize(10);
                          });
                      });

                        column.Item()
                    .PaddingTop((float)0.1, Unit.Centimetre)
                    .Background(Colors.Grey.Lighten2)
                    .Row(row =>
                    {
                        row.ConstantColumn(250).Column(column =>
                        {
                            column.Item().Text("Subtotaal").FontSize(10);
                            column.Item().Text("BTW 21,00 %").FontSize(10);
                            column.Item().Text("Brutobedrag factuur").FontSize(10);
                            column.Item().Text("Te Voldoen").FontSize(10);
                        });
                     
                        row.RelativeColumn().Column(column =>
                        {
                            column.Item().AlignCenter().Text("").FontSize(10);
                            column.Item().AlignCenter().Text("€"+Total).FontSize(10);
                        });
                        row.RelativeColumn().Column(column =>
                        {
                            column.Item().Text("€" + Total).FontSize(10);
                            column.Item().Text("€" +((BTW * Total) / 100)).FontSize(10);
                            column.Item()
                            .BorderTop(1)
                            .BorderBottom(1)
                             
                            .Text("€" + ( Total + ((BTW * Total) / 100))).FontSize(10); 
                            
                            column.Item()
                            .Text("€" + ( Total + ((BTW * Total) / 100))).FontSize(10);

                        });

                    });



                    });
                    page.Footer()
                    .Height(1, Unit.Inch).AlignCenter()
                    .Text("Gaarne uw betaling vóór 06-08-2022 o.v.v. factuurnummer 94200051 op rekeningnummerNL31INGB0651737451 ten name van CED Repair B.V..")
                    .SemiBold();



                    void HeaderFunction(IContainer container)
                    {
                        container.Row(row =>
                         {

                             row.ConstantItem(320).Column(column =>
                             {
                                 column.Item().Height(50).Width(100).Image("ced-group-social-imgn-removebg-preview.png", ImageScaling.Resize);
                                 column.Item().PaddingTop(20).Text("Allianz Nederland Groep N.V.").FontSize(10);
                                 column.Item().Text("T.a.v. mocefIBAN").FontSize(10);
                                 column.Item().Text("Coolsingel 10").FontSize(10);
                                 column.Item().Text("3016CH Rotterdam").FontSize(10);
                                 column.Item().Text("Nederland").FontSize(10);
                                 column.Item().Text("NL006650892B01").FontSize(10);
                             });

                             row.RelativeItem().Height(8, Unit.Centimetre).Column(column =>
                             {
                                 column.Item().Text("CED Repair B.V.").FontSize(12).SemiBold();
                                 column.Item().Text("Rietbaan 40 - 42").FontSize(10);
                                 column.Item().Text("2900AJ Capelle aan den IJssel").FontSize(10);
                                 column.Item().Text("T +33140000000").FontSize(10);
                                 column.Item().Text("F +33140000300").FontSize(10);
                                 column.Item().Text("test@ced.nl").FontSize(10);
                                 column.Item().Text("www.ced.nl").FontSize(10);
                                 column.Item().Text("IBAN NL31INGB0651737451").FontSize(10);
                                 column.Item().Text("BIC INGBNL2A").FontSize(10);
                                 column.Item().Text("K.v.K. 56541163").FontSize(10);
                                 column.Item().Text("BTW-nummer NL852177008B01").FontSize(10);

                             });



                         });
                    }


                });
            }).ShowInPreviewer();
            
           
            return Ok();
        }

    }
}
