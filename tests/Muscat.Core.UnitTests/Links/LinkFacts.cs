using Muscat.Core.Links;
using Muscat.Core.Links.Events;

namespace Muscat.Core.UnitTests.Links;

public class LinkFacts : UnitTest
{
    public class TheCreateNewMethod : LinkFacts
    {
        [Fact]
        public void PublishesLinkCreatedDomainEvent()
        {
            // Act
            var link = Link.CreateNew(new("https://example.org"), "Example");

            // Assert
            var linkCreated = AssertDomainEventPublished<LinkCreatedDomainEvent>(link);
            Assert.Equal(link.Id, linkCreated.LinkId);
        }
    }
}
