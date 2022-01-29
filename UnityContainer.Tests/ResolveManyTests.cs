using System.Collections.Generic;
using System.Linq;
using Unity;
using Xunit;

namespace UnityContainer.Tests;

public class ResolveManyTests
{
	[Fact]
	public void Register_family_of_types_and_resolve_notNamed()
	{
		IUnityContainer sut = new Unity.UnityContainer();
		sut.RegisterType<IMock, Dog>();
		sut.RegisterType<IMock, Squirrel>(nameof(Squirrel));
		sut.RegisterType<IMock, Cat>(nameof(Cat));

		var actual = sut.Resolve<IMock>();

		Assert.True(actual is Dog);
	}

	[Fact]
	public void Register_family_of_types_and_resolve_named()
	{
		IUnityContainer sut = new Unity.UnityContainer();
		sut.RegisterType<IMock, Dog>();
		sut.RegisterType<IMock, Squirrel>(nameof(Squirrel));
		sut.RegisterType<IMock, Cat>(nameof(Cat));

		var actual = sut.Resolve<IMock>(nameof(Cat));

		Assert.True(actual is Cat);
	}

	/// <summary>
	/// http://unitycontainer.org/tutorials/Composition/collections.html
	/// </summary>
	[Fact]
	public void Register_family_of_types_and_resolve_it_as_Array()
	{
		IUnityContainer sut = new Unity.UnityContainer();
		sut.RegisterType<IMock, Dog>();
		sut.RegisterType<IMock, Squirrel>(nameof(Squirrel));
		sut.RegisterType<IMock, Cat>(nameof(Cat));

		var actual = sut.Resolve<IMock[]>();

		Assert.True(actual[0] is Squirrel);
		Assert.True(actual[1] is Cat);
	}

	[Fact]
	public void Register_family_of_types_and_resolve_it_as_Enumerable()
	{
		IUnityContainer sut = new Unity.UnityContainer();
		sut.RegisterType<IMock, Dog>();
		sut.RegisterType<IMock, Squirrel>(nameof(Squirrel));
		sut.RegisterType<IMock, Cat>(nameof(Cat));

		var actual = sut.Resolve<IEnumerable<IMock>>();

		Assert.True(actual.ElementAt(0) is Dog);
		Assert.True(actual.ElementAt(1) is Squirrel);
		Assert.True(actual.ElementAt(2) is Cat);
	}

	[Fact]
	public void Register_family_of_types_and_resolve_it_as_List()
	{
		IUnityContainer sut = new Unity.UnityContainer();
		sut.RegisterType<IMock, Dog>();
		sut.RegisterType<IMock, Squirrel>(nameof(Squirrel));
		sut.RegisterType<IMock, Cat>(nameof(Cat));

		var actual = sut.Resolve<List<IMock>>();

		Assert.True(actual[0] is Dog);
		Assert.True(actual[1] is Squirrel);
		Assert.True(actual[2] is Cat);
	}
}