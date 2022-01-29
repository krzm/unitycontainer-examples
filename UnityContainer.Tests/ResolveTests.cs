using System;
using Unity;
using Unity.Injection;
using Xunit;

namespace UnityContainer.Tests;

public class ResolveTests
{
	[Fact]
	public void Register_and_resolve_type_with_its_interface()
	{
		var sut = new Unity.UnityContainer();
		sut.RegisterType<IMock, Cat>();

		var actual = sut.Resolve<IMock>();

		Assert.True(actual is Cat);
	}

	[Fact]
	public void Register_and_resolve_type_with_Primitive_Type_Parameter()
	{
		var sut = new Unity.UnityContainer();
		sut.RegisterType<IMock, DataWrapper>(
			new InjectionConstructor(new object[] { Array.Empty<string>() }));

		var actual = sut.Resolve<IMock>();

		Assert.True(actual is DataWrapper);
	}
}