using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace FormGenerator
{
    public class Migrations : DataMigrationImpl
    {

        public int Create()
        {
            // Creating table Class
            SchemaBuilder.CreateTable("Class", table => table
                .ContentPartRecord()
                .Column("Name", DbType.String)
                .Column("DefaultEmail", DbType.String)
            );

            // Creating table Property
            SchemaBuilder.CreateTable("Property", table => table
                .ContentPartRecord()
                .Column("Name", DbType.String)
                .Column("Settings", DbType.String)
                .Column("Class_id", DbType.Int32)
            );

            // Creating table Object
            SchemaBuilder.CreateTable("Object", table => table
                .ContentPartRecord()
                .Column("ValidationMessage", DbType.String)
                .Column("Created", DbType.DateTime)
                .Column("Class_id", DbType.Int32)
            );

            // Creating table Value
            SchemaBuilder.CreateTable("Value", table => table
                .ContentPartRecord()
                .Column("value", DbType.String)
                .Column("ValidationMessage", DbType.String)
                .Column("Property_id", DbType.Int32)
                .Column("Object_id", DbType.Int32)
            );

            // Creating table DisplayContext
            SchemaBuilder.CreateTable("DisplayContext", table => table
                .ContentPartRecord()
                .Column("Name", DbType.String)
                .Column("Type", DbType.String)
                .Column("Property_id", DbType.Int32)
            );


            ContentDefinitionManager.AlterTypeDefinition("Form", cfg => cfg
                .WithPart("FormDefinitionPart")
                .WithPart("CommonPart")
                .Creatable()
                );

            return 1;
        }

        public int UpdateFrom1()
        {
            ContentDefinitionManager.AlterTypeDefinition("DisplayContext", cfg => cfg
             .WithPart("DisplayContextPart")
             );
            ContentDefinitionManager.AlterTypeDefinition("Property", cfg => cfg
                .WithPart("PropertyPart")
                );
            return 2;
        }

        public int UpdateFrom2()
        {
            ContentDefinitionManager.AlterTypeDefinition("Form", cfg => cfg
                    .WithPart("FormPart")
                    .WithPart("CommonPart")
                    .Creatable()
                    );
            return 3;
        }
    }
}