using System;
using Xunit;
using DotNet_Gram.Models;
using DotNet_Gram.Models.Services;
using DotNet_Gram.Models.Interfaces;
using DotNet_Gram.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void GetWorks()
        {
            //arrange
            NetGram netGram = new NetGram();
            netGram.Caption = "nice pic";

            //assert
            Assert.Equal("nice pic", netGram.Caption);
        }

        [Fact]
        public void GetWorksAgain()
        {
            //arrange
            NetGram netGram = new NetGram();
            netGram.Caption = "nice pic";
            netGram.NamePoster = "Jason";

            //assert
            Assert.Equal("Jason", netGram.NamePoster);
        }

        [Fact]
        public void SetWorks()
        {
            //arrange
            NetGram netGram = new NetGram();
            netGram.Caption = "nice pic";
            netGram.NamePoster = "Jason";

            //Act
            netGram.Caption = "crappy pic";
            //assert
            Assert.Equal("crappy pic", netGram.Caption);
        }

        [Fact]
        public void SetWorksAgain()
        {
            //arrange
            NetGram netGram = new NetGram();
            netGram.Caption = "nice pic";
            netGram.NamePoster = "Jason";

            //Act
            netGram.NamePoster = "Jennifer";
            //assert
            Assert.Equal("Jennifer", netGram.NamePoster);
        }

        [Fact]
        public async void CreateGramWorks()
        {
            DbContextOptions<NetGramDbContext> options =
                new DbContextOptionsBuilder<NetGramDbContext>
                ().UseInMemoryDatabase("Create").Options;

            using (NetGramDbContext context = new NetGramDbContext(options))
            {
                // arrange
                NetGram netGram = new NetGram();
                netGram.ID = 1;
                netGram.NamePoster = "Jason";
                netGram.Caption = "Seattle";
              

                // Act
                NetGramManager netGramManager = new NetGramManager(context);

                await netGramManager.SaveNetGram(netGram);
                var created = context.NetGrams.FirstOrDefault(n => n.ID == netGram.ID);

                // Assert
                Assert.Equal(netGram, created);

            }
        }

        [Fact]
        public async void CreateGramWorksAgain()
        {
            DbContextOptions<NetGramDbContext> options =
                new DbContextOptionsBuilder<NetGramDbContext>
                ().UseInMemoryDatabase("Create").Options;

            using (NetGramDbContext context = new NetGramDbContext(options))
            {
                // arrange
                NetGram netGram = new NetGram();
                netGram.ID = 2;
                netGram.NamePoster = "Jason";
                netGram.Caption = "Seattle";


                // Act
                NetGramManager netGramManager = new NetGramManager(context);

                await netGramManager.SaveNetGram(netGram);
                var created = context.NetGrams.FirstOrDefault(n => n.ID == netGram.ID);

                // Assert
                Assert.Equal(netGram, created);

            }
        }

        [Fact]
        public async void DeleteGramWorks()
        {
            DbContextOptions<NetGramDbContext> options =
                new DbContextOptionsBuilder<NetGramDbContext>
                ().UseInMemoryDatabase("Delete").Options;

            using (NetGramDbContext context = new NetGramDbContext(options))
            {
                // arrange
                NetGram netGram = new NetGram();
                netGram.ID = 1;
                netGram.NamePoster = "Jason";
                netGram.Caption = "Seattle";


                // Act
                NetGramManager netGramManager = new NetGramManager(context);

                await netGramManager.SaveNetGram(netGram);

                await netGramManager.Delete(1);

                var deleted = context.NetGrams.FirstOrDefault(n => n.ID == netGram.ID);

                // Assert
                Assert.Null(deleted);

            }
        }

        [Fact]
        public async void DeleteGramWorksAgain()
        {
            DbContextOptions<NetGramDbContext> options =
                new DbContextOptionsBuilder<NetGramDbContext>
                ().UseInMemoryDatabase("Delete").Options;

            using (NetGramDbContext context = new NetGramDbContext(options))
            {
                // arrange
                NetGram netGram = new NetGram();
                netGram.ID = 2;
                netGram.NamePoster = "Jason";
                netGram.Caption = "Seattle";


                // Act
                NetGramManager netGramManager = new NetGramManager(context);

                await netGramManager.SaveNetGram(netGram);

                await netGramManager.Delete(2);

                var deleted = context.NetGrams.FirstOrDefault(n => n.ID == netGram.ID);

                // Assert
                Assert.Null(deleted);

            }
        }

        [Fact]
        public async void EditGramWorks()
        {
            DbContextOptions<NetGramDbContext> options =
                new DbContextOptionsBuilder<NetGramDbContext>
                ().UseInMemoryDatabase("Edit").Options;

            using (NetGramDbContext context = new NetGramDbContext(options))
            {
                // arrange
                NetGram netGram = new NetGram();
                netGram.ID = 2;
                netGram.NamePoster = "Jason";
                netGram.Caption = "Seattle";


                // Act
                NetGramManager netGramManager = new NetGramManager(context);

                await netGramManager.SaveNetGram(netGram);

                netGram.NamePoster = "Jennifer";

                await netGramManager.SaveNetGram(netGram);

                // Assert
                Assert.Equal("Jennifer", netGram.NamePoster);

            }
        }

        [Fact]
        public async void EditGramWorksAgain()
        {
            DbContextOptions<NetGramDbContext> options =
                new DbContextOptionsBuilder<NetGramDbContext>
                ().UseInMemoryDatabase("Edits").Options;

            using (NetGramDbContext context = new NetGramDbContext(options))
            {
                // arrange
                NetGram netGram = new NetGram();
                netGram.ID = 2;
                netGram.NamePoster = "Jason";
                netGram.Caption = "Seattle";


                // Act
                NetGramManager netGramManager = new NetGramManager(context);

                await netGramManager.SaveNetGram(netGram);

                netGram.Caption = "Wow";

                await netGramManager.SaveNetGram(netGram);

                // Assert
                Assert.Equal("Wow", netGram.Caption);

            }
        }

    }
}
