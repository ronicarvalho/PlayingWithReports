using System.Net.Mime;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

Document.Create(document =>
{
    document.Page(page =>
    {
        page.Size(PageSizes.A4);
        page.Margin(1.5f, Unit.Centimetre);
        page.PageColor(Colors.White);
        page.DefaultTextStyle(f => f.FontSize(9));

        page.Header()
            .Row(row =>
            {
                row.RelativeItem(2)
                    .AlignLeft()
                    .Element(ItemStyle)
                    .Text("Nº total de viaturas no acidente: ________");

                row.RelativeItem(1)
                    .Element(ItemStyle)
                    .Text("Data: ___/___/______");

                row.RelativeItem(1)
                    .Element(ItemStyle)
                    .Text("Folha 1/______");

                static IContainer ItemStyle(IContainer container) => container
                    .AlignRight()
                    .Border(1)
                    .Padding(2.5f);
            });

        page.Content()
            .Column(column =>
            {
                column.Item()
                    .PaddingVertical(15)
                    .Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(20);
                            columns.RelativeColumn();
                            columns.ConstantColumn(220);
                            columns.RelativeColumn();
                        });

                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Secção Corrente");
                        table.Cell().Row(row =>
                        {
                            row.RelativeItem().Element(CellStyle).Text("AE / IP / IC / EN: _______");
                            row.ConstantItem(1).LineVertical(1);
                            row.RelativeItem().Element(CellStyle).Text("KM: ________ + ________");
                        });
                        table.Cell().Element(CellStyle).Text("Sentido: _____________________");

                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Portagem");
                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Via nº: _______________________");

                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Nó");
                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Ramo: _______________________");

                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Acesso rede exterior");
                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Sentido: _____________________");

                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Área de Serviço / Repouso");
                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Sentido: _____________________");

                        static IContainer CellStyle(IContainer container) => container
                            .Border(1)
                            .PaddingLeft(5)
                            .BorderColor(Colors.Black)
                            .PaddingVertical(2);
                    });

                column.Item()
                    .Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.ConstantColumn(40);
                            columns.RelativeColumn();
                            columns.ConstantColumn(40);
                            columns.RelativeColumn();
                            columns.ConstantColumn(40);
                            columns.RelativeColumn();
                            columns.ConstantColumn(40);
                        });

                        table.Header(header =>
                        {
                            header.Cell().ColumnSpan(8).Element(HeaderStyle).Row(row =>
                                row.RelativeItem().Element(TextStyle).Text("Actividades AR"));

                            static IContainer TextStyle(IContainer container) => container
                                .DefaultTextStyle(ts => ts.ExtraBold())
                                .PaddingVertical(2)
                                .AlignCenter();

                            static IContainer HeaderStyle(IContainer container) => container
                                .Border(1)
                                .BorderColor(Colors.Black);
                        });

                        table.Cell().Element(CellStyle).Text("Hora Comunicação");
                        table.Cell().Element(CenteredCellStyle).Text(":");
                        table.Cell().Element(CellStyle).Text("Origem Participação");
                        table.Cell().Element(CenteredCellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Hora Acidente");
                        table.Cell().Element(CenteredCellStyle).Text(":");
                        table.Cell().Element(CellStyle).Text("Chegada Local (AR)");
                        table.Cell().Element(CenteredCellStyle).Text(":");

                        table.Cell().Element(CellStyle).Text("Situação Normal às");
                        table.Cell().Element(CenteredCellStyle).Text(":");
                        table.Cell().ColumnSpan(6).Element(CellStyle).Text("Obs");

                        static IContainer CellStyle(IContainer container) => container
                            .Border(1)
                            .PaddingLeft(5)
                            .BorderColor(Colors.Black)
                            .PaddingVertical(2);

                        static IContainer CenteredCellStyle(IContainer container) => container
                            .Border(1)
                            .BorderColor(Colors.Black)
                            .AlignCenter();
                    });

                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(90);
                        columns.ConstantColumn(70);
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });

                    table.Header(header =>
                    {
                        header.Cell().ColumnSpan(4).Element(HeaderStyle).Row(row =>
                            row.RelativeItem().Element(TextStyle).Text("Meios externos à Brisa"));

                        static IContainer TextStyle(IContainer container) => container
                            .DefaultTextStyle(ts => ts.ExtraBold())
                            .PaddingVertical(2)
                            .AlignCenter();

                        static IContainer HeaderStyle(IContainer container) => container
                            .Border(1)
                            .BorderColor(Colors.Black);
                    });

                    table.Cell().Element(CenteredCellStyle).Text("");
                    table.Cell().Element(CenteredCellStyle).Text("Hora Chegada");
                    table.Cell().Element(CenteredCellStyle).Text("Nome / Destacamento / Corporação");
                    table.Cell().Element(CenteredCellStyle).Text("Actividades Efectuadas");
                    
                    table.Cell().Element(CellStyle).Text("GNR / PS");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");
                    
                    table.Cell().Element(CellStyle).Text("Ambulância");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");
                    
                    table.Cell().Element(CellStyle).Text("=");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");
                    
                    table.Cell().Element(CellStyle).Text("Bombeiros");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");
                    
                    table.Cell().Element(CellStyle).Text("=");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");
                    
                    table.Cell().Element(CellStyle).Text("BCI");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");
                    
                    table.Cell().Element(CellStyle).Text("Outros");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");
                    
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");
                    
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");
                    
                    static IContainer CellStyle(IContainer container) => container
                        .Border(1)
                        .PaddingLeft(5)
                        .BorderColor(Colors.Black)
                        .PaddingVertical(2);

                    static IContainer CenteredCellStyle(IContainer container) => container
                        .Border(1)
                        .BorderColor(Colors.Black)
                        .AlignCenter()
                        .DefaultTextStyle(ts => ts.ExtraBold());
                });
            });
    });
}).ShowInPreviewer();