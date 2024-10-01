using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using System.Collections.ObjectModel;
using Xunit;

namespace Lab1.Tests;

public class SimulatorTests
{
    [Fact]
    public void TestCase1()
    {
        var train = new Train(new Force(100), new Weight(1));
        var parts = new List<BaseRoutePart>
        {
            new MagneticForceRoute(new Force(1), new Distance(100)),
            new MagneticRoute(new Distance(100)),
        };
        var routeParts = new ReadOnlyCollection<BaseRoutePart>(parts);

        var route = new Route(routeParts, new Speed(100));
        var sim = new Simulator(route, train, 10);

        sim.FollowTheRoute();
    }

    [Fact]
    public void TestCase2()
    {
        var train = new Train(new Force(100000), new Weight(1));
        var parts = new List<BaseRoutePart>
        {
            new MagneticForceRoute(new Force(10000), new Distance(100)),
            new MagneticRoute(new Distance(100)),
        };
        var routeParts = new ReadOnlyCollection<BaseRoutePart>(parts);

        var route = new Route(routeParts, new Speed(100));
        var sim = new Simulator(route, train, 1);

        ArgumentException exception = Assert.Throws<ArgumentException>(() => sim.FollowTheRoute());
        Assert.Equal("Speed cannot be greater than the force module value.", exception.Message);
    }

    [Fact]
    public void TestCase3()
    {
        var train = new Train(new Force(100), new Weight(100));
        var parts = new List<BaseRoutePart>
        {
            new MagneticForceRoute(new Force(1), new Distance(100)),
            new MagneticRoute(new Distance(100)),
            new Station(new Speed(10000), 10),
            new MagneticRoute(new Distance(100)),
        };
        var routeParts = new ReadOnlyCollection<BaseRoutePart>(parts);

        var route = new Route(routeParts, new Speed(100));
        var sim = new Simulator(route, train, 10);

        sim.FollowTheRoute();
    }

    [Fact]
    public void TestCase4()
    {
        var train = new Train(new Force(100000), new Weight(1));
        var parts = new List<BaseRoutePart>
        {
            new MagneticForceRoute(new Force(10000), new Distance(100)),
            new Station(new Speed(100), 10),
            new MagneticRoute(new Distance(100)),
        };
        var routeParts = new ReadOnlyCollection<BaseRoutePart>(parts);

        var route = new Route(routeParts, new Speed(100));
        var sim = new Simulator(route, train, 1);

        ArgumentException exception = Assert.Throws<ArgumentException>(() => sim.FollowTheRoute());
        Assert.Equal("Speed must be less than speed limit of station.", exception.Message);
    }

    [Fact]
    public void TestCase5()
    {
        var train = new Train(new Force(1000000), new Weight(1));
        var parts = new List<BaseRoutePart>
        {
            new MagneticForceRoute(new Force(10), new Distance(100)),
            new Station(new Speed(100), 10),
            new MagneticRoute(new Distance(100)),
        };
        var routeParts = new ReadOnlyCollection<BaseRoutePart>(parts);

        var route = new Route(routeParts, new Speed(1));
        var sim = new Simulator(route, train, 1);

        ArgumentException exception = Assert.Throws<ArgumentException>(() => sim.FollowTheRoute());
        Assert.Equal("Speed cannot be greater than the force module value.", exception.Message);
    }

    [Fact]
    public void TestCase6()
    {
        var train = new Train(new Force(100000), new Weight(1));
        var parts = new List<BaseRoutePart>
        {
            new MagneticForceRoute(new Force(3), new Distance(1)),
            new MagneticRoute(new Distance(1)),
            new MagneticForceRoute(new Force(-1), new Distance(1)),
            new Station(new Speed(2), 5),
            new MagneticRoute(new Distance(1)),
            new MagneticForceRoute(new Force(3), new Distance(1)),
            new MagneticRoute(new Distance(1)),
            new MagneticForceRoute(new Force(-3), new Distance(1)),
        };
        var routeParts = new ReadOnlyCollection<BaseRoutePart>(parts);

        var route = new Route(routeParts, new Speed(2));
        var sim = new Simulator(route, train, 1);

        sim.FollowTheRoute();
    }

    [Fact]
    public void TestCase7()
    {
        var train = new Train(new Force(100000), new Weight(1));
        var parts = new List<BaseRoutePart>
        {
            new MagneticRoute(new Distance(1)),
        };
        var routeParts = new ReadOnlyCollection<BaseRoutePart>(parts);

        var route = new Route(routeParts, new Speed(2));
        var sim = new Simulator(route, train, 1);

        ArgumentException exception = Assert.Throws<ArgumentException>(() => sim.FollowTheRoute());
        Assert.Equal("Speed cannot be negative", exception.Message);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 3)]
    public void TestCase8(double x, double y)
    {
        var train = new Train(new Force(100000), new Weight(1));
        var parts = new List<BaseRoutePart>
        {
            new MagneticForceRoute(new Force(y), new Distance(x)),
            new MagneticForceRoute(new Force(-2 * y), new Distance(x)),
        };
        var routeParts = new ReadOnlyCollection<BaseRoutePart>(parts);

        var route = new Route(routeParts, new Speed(2));
        var sim = new Simulator(route, train, 1);

        ArgumentException exception = Assert.Throws<ArgumentException>(() => sim.FollowTheRoute());
        Assert.Equal("Speed cannot be negative", exception.Message);
    }
}