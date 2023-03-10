using AutoMapper;
using QuestPDF.Fluent;
using QuestPDF.Previewer;
using Generation_Documents.Models;
using Generation_Documents.Services;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Infrastructure;
using QuestPDF.Elements;
using QuestPDF.Helpers;
using Microsoft.AspNetCore.Components;
using System.Linq;
using static QuestPDF.Helpers.Colors;
using QuestPDF.Drawing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace Generation_Documents.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("API/2")]
    public class HomeController : ControllerBase
    {

        private readonly IMapper _Mapper;
        private readonly IDataRepository _DataRepository;

        public HomeController(IDataRepository DataRepository, IMapper mapper)
        {
            _Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _DataRepository = DataRepository ?? throw new ArgumentNullException(nameof(DataRepository));
        }



        [HttpPost]
        public  ActionResult<SalesInvoiceDTO> GenerateSalesI(RecivedDataDTO recivedDataDTO, int btw)
        {


            var BTW = (float)21.0F;
            float[] pricesArray = { 1F, 1F, 1F, 1F };

            List<float> totalsArray = new List<float>();


            QuestPDF.Fluent.Document.Create(document =>
            {

                document.Page( page =>
                {


                    page.Margin((float)1.5, Unit.Centimetre);
                    page.MarginRight(2, Unit.Centimetre);
                    page.MarginLeft(2, Unit.Centimetre);

                    page.Header().Element(HeaderFunction);

                    //page.Content().Element(ContainerFunction);

                    var CD =  new containerDynamic(pricesArray, BTW);
                    page.Content().Dynamic(CD);
                    totalsArray = CD.totalsArray;
                    page.Footer().Dynamic( new FooterDynamic(totalsArray,BTW));



                });


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



            }).ShowInPreviewer();

            return Ok();

        }

        // dynamic container and footer  

        public class containerDynamic : IDynamicComponent<float>
        {


            public float State { get; set; }
            public float BTW { get; }
            public float Total { get; private set; } = 0;

            public float[] pricesArray;

            public List<float> totalsArray { get; set; } = new List<float>();

            public containerDynamic(float[] pricesArray, float B)
            {
                this.BTW = B;
                this.pricesArray = pricesArray;

            }


            public DynamicComponentComposeResult Compose(DynamicContext context)
            {

                var content = context.CreateElement(element =>
                {


                    element.Column(column =>
                    {




                        column.Item().BorderBottom(1).Height(20).AlignCenter()
                              .Text("Sales invoice").FontSize(12);

                        column.Item().Row(row =>
                        {
                            // loop 
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
                        .PaddingTop((float)0.5, Unit.Centimetre)
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

                        var globalIndex = 0;
                        var pageN = 1;

                         column.Item().Row(row =>
                        {

                        foreach (var i in Enumerable.Range(0, pricesArray.Length))
                            {
   

                            if (pageN != context.PageNumber)
                            {
                                Total = 0;

                                foreach (var j in Enumerable.Range(0, i))
                                {
                                    Total = Total + pricesArray[j];
                                }

                                totalsArray.Add(Total);
                                globalIndex = globalIndex + 1;
                                pageN = context.PageNumber;

                            }
                            else
                            {


                                if (i == 0)
                                {
                                    totalsArray.Add(pricesArray[i]);
                                }
                                else
                                {
                                    totalsArray[globalIndex] = totalsArray[globalIndex]+ pricesArray[i];
                                }
                            }





                                column.Item().ShowEntire()
                          .PaddingTop((float)0.1, Unit.Centimetre)
                          .PaddingBottom((float)0.1, Unit.Centimetre).Row(row =>
                          {
                              row.ConstantColumn(200).Column(column =>
                              {
                                  column.Item().Text("Toeslag spoedopdracht (arbeid)gyugyugugyuyu").FontSize(10);
                              });
                              row.RelativeColumn().Column(column =>
                              {
                                  column.Item().AlignCenter().Text("1 post").FontSize(10);
                              });
                              row.RelativeColumn().Column(column =>
                              {
                                  column.Item().AlignCenter().Text("€320,00").FontSize(10);
                              });
                              row.RelativeColumn().Column(column =>
                              {
                                  column.Item().AlignCenter().Text("€" + pricesArray[i]).FontSize(10);
                              });
                              row.RelativeColumn().Column(column =>
                              {
                                  column.Item().AlignCenter().Text(BTW + "%").FontSize(10);
                              });
                          });
                            } 
                  
                                //totalsArray.ForEach(x => Console.WriteLine(x));
                                
                        });

                    });
                });

                return new DynamicComponentComposeResult
                {
                    Content = content,
                    HasMoreContent = false
                };
            }


        }

        public class FooterDynamic : IDynamicComponent<float>
        {

            public int pageNumberOut { get; set; }
            public float State { get; set; }
            public List<float> Totals { get; private set; }
            public float BTW { get; private set; }

            public FooterDynamic(List<float> totals, float B)
            {
                this.BTW = B;
                this.Totals = totals;

            }
            public FooterDynamic() { }

            public DynamicComponentComposeResult Compose(DynamicContext context)
            {

                var content = context.CreateElement(element =>
                {


                    element.Row(row =>
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
                            column.Item().AlignCenter().Text("€" + this.Totals[context.PageNumber - 1]).FontSize(10);


                        });
                        row.RelativeColumn().Column(column =>
                        {
                            
                            column.Item().Text("€" + this.Totals[context.PageNumber - 1]).FontSize(10);
                            column.Item().Text("€" + ((this.BTW * this.Totals[context.PageNumber - 1])) / 100).FontSize(10);
                            column.Item()
                            .BorderTop(1)
                            .BorderBottom(1)

                            .Text("€" + (this.Totals[context.PageNumber - 1]) + ((this.BTW * this.Totals[context.PageNumber - 1])) / 100).FontSize(10);

                            column.Item()
                            .Text("€" + (this.Totals[context.PageNumber - 1]) + ((this.BTW * this.Totals[context.PageNumber - 1])) / 100).FontSize(10);

                        });

                    });
                });

                return new DynamicComponentComposeResult
                {
                    Content = content,
                    HasMoreContent = false
                };

            }
        }


    }
}




























