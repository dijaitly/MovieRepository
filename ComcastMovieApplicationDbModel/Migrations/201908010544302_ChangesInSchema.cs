namespace ComcastMovieApplicationDbModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInSchema : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.MovieRatings", "Rating", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false, maxLength: 1000));
            CreateIndex("dbo.Movies", "Title", name: "Idx_Movie_Title");
            CreateIndex("dbo.Movies", "YearOfRelease", name: "Idx_Movie_YearOfRelease");
            CreateIndex("dbo.Movies", "Genre", name: "Idx_Movie_Genre");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Movies", "Idx_Movie_Genre");
            DropIndex("dbo.Movies", "Idx_Movie_YearOfRelease");
            DropIndex("dbo.Movies", "Idx_Movie_Title");
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.MovieRatings", "Rating", c => c.Double(nullable: false));
            DropColumn("dbo.Movies", "Genre");
        }
    }
}
