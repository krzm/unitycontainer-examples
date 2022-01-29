using System.Collections.Generic;
using Unity;
using Xunit;

namespace UnityContainer.Tests;

public class ContainerFactoryTests
{
	[Fact]
	public void Register_family_of_types_as_dictionary_and_resolve_it()
	{
		var sut = new Unity.UnityContainer();
		sut.RegisterType<IMock, Squirrel>("Squirrel");
		sut.RegisterType<IMock, Cat>("Cat");
		sut.RegisterType<IMock, Dog>("Dog");
		sut.RegisterFactory<IDictionary<string, IMock>>(
			"Dictionary"
			, m => new Dictionary<string, IMock>
			{
				{ "Squirrel", m.Resolve<IMock>("Squirrel") }
				, { "Cat", m.Resolve<IMock>("Cat") }
				, { "Dog", m.Resolve<IMock>("Dog") }
			});

		var resolved = sut.Resolve<IDictionary<string, IMock>>("Dictionary");

		Assert.True(resolved["Dog"] is Dog);
	}
}