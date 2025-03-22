using FluentMigrator;
using Nop.Data.Migrations;

namespace Jose.Plugin.Widgets.CustomCarousel.Data.Migrations;

[NopSchemaMigration("2025/03/22 19:03:55:1687541", "Widgets.CustomCarousel base schema", MigrationProcessType.Installation)]
public class InitialSchemaMigration : ForwardOnlyMigration
{
    public override void Up()
    {
        if (!Schema.Table("Carousel").Exists())
        {
            Execute.Sql(@"CREATE TABLE [dbo].[Carousel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarouselName] [nvarchar](200) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Published] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Carousel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]");
        }

        if (!Schema.Table("CarouselImage").Exists())
        {
	        Execute.Sql(@"CREATE TABLE [dbo].[CarouselImage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarouselId] [int] NOT NULL,
	[ImageId] [int] NOT NULL,
	[MobileImageId] [int] NOT NULL,
	[Link] [nvarchar](200) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Published] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_CarouselImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]");
        }
    }
}