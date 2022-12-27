using Muscat.Core.Domains;
using Muscat.Core.Domains.Events;

namespace Muscat.Core.UnitTests.Domains;

public class DomainFacts : UnitTest
{
    public class TheCreateNewMethod : DomainFacts
    {
        [Fact]
        public void PublishesDomainCreatedDomainEvent()
        {
            // Act
            var domain = Domain.CreateNew(new("https://example.org"), "Example");

            // Assert
            var domainCreated = AssertDomainEventPublished<DomainCreatedDomainEvent>(domain);
            Assert.Equal(domain.Id, domainCreated.DomainId);
        }
    }
}
