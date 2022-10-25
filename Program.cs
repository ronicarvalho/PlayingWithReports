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
        page.PageColor("#F2F7FA");
        page.DefaultTextStyle(f => f.FontSize(10));

        page.Header()
            .Row(row =>
            {
                row.RelativeItem(2)
                    .AlignLeft()
                    .Width(114)
                    .Height(104)
                    .Image("logo.png");

                row.RelativeItem(1)
                    .Element(ItemStyle)
                    .Text("Data: ___/___/______");

                row.RelativeItem(1)
                    .Element(ItemStyle)
                    .Text(text =>
                    {
                        text.Span("Folha ");
                        text.CurrentPageNumber();
                        text.Span("/______");
                    });

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
                        table.Cell().Element(CellStyle).Text("Seção Atual");
                        table.Cell().Row(row =>
                        {
                            row.RelativeItem().Element(CellStyle).Text("A1 / A2 / A3 / A4: _______");
                            row.ConstantItem(1).LineVertical(1);
                            row.RelativeItem().Element(CellStyle).Text("DS: ________ + ________");
                        });
                        table.Cell().Element(CellStyle).Text("Localidade: _____________________");

                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Danos");
                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Visíveis: _______________________");

                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Quartos");
                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Visíveis: _______________________");

                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Banheiros");
                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Visíveis: _____________________");

                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Área de Serviço");
                        table.Cell().Element(CellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Visíveis: _____________________");

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
                                row.RelativeItem().Element(TextStyle).Text("Informações Extras"));

                            static IContainer TextStyle(IContainer container) => container
                                .DefaultTextStyle(ts => ts.ExtraBold())
                                .PaddingVertical(2)
                                .AlignCenter();

                            static IContainer HeaderStyle(IContainer container) => container
                                .Border(1)
                                .BorderColor(Colors.Black);
                        });

                        table.Cell().Element(CellStyle).Text("Hora da Chegada");
                        table.Cell().Element(CenteredCellStyle).Text(":");
                        table.Cell().Element(CellStyle).Text("Acompanhado");
                        table.Cell().Element(CenteredCellStyle).Text("");
                        table.Cell().Element(CellStyle).Text("Hora da Saída");
                        table.Cell().Element(CenteredCellStyle).Text(":");
                        table.Cell().Element(CellStyle).Text("Início da Vistoria");
                        table.Cell().Element(CenteredCellStyle).Text(":");

                        table.Cell().Element(CellStyle).Text("Final da Vistoria");
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
                            row.RelativeItem().Element(TextStyle).Text("Análise"));

                        static IContainer TextStyle(IContainer container) => container
                            .DefaultTextStyle(ts => ts.ExtraBold())
                            .PaddingVertical(2)
                            .AlignCenter();

                        static IContainer HeaderStyle(IContainer container) => container
                            .Border(1)
                            .BorderColor(Colors.Black);
                    });

                    table.Cell().Element(CenteredCellStyle).Text("");
                    table.Cell().Element(CenteredCellStyle).Text("Campo 1");
                    table.Cell().Element(CenteredCellStyle).Text("Campo 2");
                    table.Cell().Element(CenteredCellStyle).Text("Campo 3");

                    table.Cell().Element(CellStyle).Text("APD / TR");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");

                    table.Cell().Element(CellStyle).Text("Campo 4");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");

                    table.Cell().Element(CellStyle).Text("=");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");

                    table.Cell().Element(CellStyle).Text("Campo 5");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");

                    table.Cell().Element(CellStyle).Text("=");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");

                    table.Cell().Element(CellStyle).Text("Campo 6");
                    table.Cell().Element(CenteredCellStyle).Text(":");
                    table.Cell().Element(CellStyle).Text("");
                    table.Cell().Element(CellStyle).Text("");

                    table.Cell().Element(CellStyle).Text("Campo 7");
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

                column.Item()
                    .PaddingVertical(15)
                    .BorderTop(1)
                    .BorderBottom(1)
                    .BorderColor(Colors.Black)
                    .Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        
                        table.Header(header =>
                        {
                            header.Cell().Row(row =>
                                row.RelativeItem().Element(TextStyle).Text("Campo 8"));
                            
                            header.Cell().Row(row =>
                                row.RelativeItem().Element(TextStyle).Text("Campo 9"));
                            
                            header.Cell().Row(row =>
                                row.RelativeItem().Element(TextStyle).Text("Campo 10"));
                            
                            header.Cell().Row(row =>
                                row.RelativeItem().Element(TextStyle).Text("Campo  11"));

                            static IContainer TextStyle(IContainer container) => container
                                .DefaultTextStyle(ts => ts.ExtraBold())
                                .PaddingVertical(2)
                                .AlignCenter();
                        });
                        
                        table.Cell().Element(CellStyle).Column(column1 =>
                        {
                            column1.Item().Text("Campo 11");
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 12");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 13");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 14");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 15");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 16");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 17");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 18");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 19");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 20");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 21");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 22");
                            });
                            
                            column1.Item().PaddingTop(10).Text("Campo 23");
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 24");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 25");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 26");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 27");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 28");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 29");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 30");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 31");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 32");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 33");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 34");
                            });
                            column1.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                        });
                        
                        table.Cell().Element(CellStyle).Column(column2 =>
                        {
                            column2.Item().Text("Campo 36");
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            
                            
                            column2.Item().PaddingTop(10).Text("Campo 35");
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            
                            
                            column2.Item().PaddingTop(10).Text("Campo 35");
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column2.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                        });
                        
                        table.Cell().Element(CellStyle).Column(column3 =>
                        {
                            column3.Item().Text("Campo 35");
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            
                            
                            column3.Item().PaddingTop(10).Text("Campo 35");
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            
                            column3.Item().PaddingTop(10).Text("Campo 35");
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            
                            
                            column3.Item().PaddingTop(10).Text("Campo 35");
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column3.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                        });
                        
                        table.Cell().Element(CellStyle).Column(column4 =>
                        {
                            column4.Item().Text("Campo 35");
                            column4.Item().Text("Campo 35");
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            
                            
                            column4.Item().PaddingTop(10).Text("Veículo");
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            
                            
                            column4.Item().PaddingTop(10).Text("Campo 35");
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            
                            
                            column4.Item().PaddingTop(10).Text("Campo 35");
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                            column4.Item().Element(ItemStyle).Row(row =>
                            {
                                row.ConstantItem(15).Element(BoxStyle).Text(" ");
                                row.RelativeItem().Element(LabelStyle).Text("Campo 35");
                            });
                        });

                        static IContainer ItemStyle(IContainer container) => container
                            .PaddingTop(3);
                        
                        static IContainer CellStyle(IContainer container) => container
                            .PaddingLeft(5).PaddingVertical(2);
                        
                        static IContainer BoxStyle(IContainer container) => container
                            .Height(15).Border(1).BorderColor(Colors.Black);
                            
                        static IContainer LabelStyle(IContainer container) => container
                            .PaddingLeft(5);
                    });
            });
    });
}).ShowInPreviewer();