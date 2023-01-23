﻿using System;
using Order_Shipping;
using OrderShipping.Domain;
using OrderShipping.Domain.Exception;
using OrderShipping.UseCase;
using OrderShippingTest.Doubles;
using Xunit;

namespace OrderShippingTest.UseCase;

public class OrderApprovalUseCaseTest
{
    private readonly TestOrderRepository _orderRepository;
    private readonly OrderApprovalUseCase _useCase;

    public OrderApprovalUseCaseTest()
    {
        _orderRepository = new TestOrderRepository();
        _useCase = new OrderApprovalUseCase(_orderRepository);
    }


    [Fact]
    public void ApprovedExistingOrder()
    {
        var initialOrder = new Order
        {
            State= new CreatedState(),
            Id = 1
        };
        _orderRepository.AddOrder(initialOrder);

        var request = new OrderApprovalRequest
        {
            OrderId = 1,
            Approved = true
        };

        _useCase.Run(request);

        var savedOrder = _orderRepository.GetSavedOrder();
        Assert.True(savedOrder.State.GetType() == typeof(ApprovedState));
    }

    [Fact]
    public void RejectedExistingOrder()
    {
        var initialOrder = new Order
        {
            State = new CreatedState(),
            Id = 1
        };
        _orderRepository.AddOrder(initialOrder);

        var request = new OrderApprovalRequest
        {
            OrderId = 1,
            Approved = false
        };

        _useCase.Run(request);

        var savedOrder = _orderRepository.GetSavedOrder();
        Assert.Equal(typeof(RejectedState), savedOrder.State.GetType());
    }


    [Fact]
    public void CannotApproveRejectedOrder()
    {
        var initialOrder = new Order
        {
            Id = 1,
            State = new RejectedState()
        };
        _orderRepository.AddOrder(initialOrder);

        var request = new OrderApprovalRequest
        {
            OrderId = 1,
            Approved = true
        };


        Action actionToTest = () => _useCase.Run(request);

        Assert.Throws<RejectedOrderCannotBeApprovedException>(actionToTest);
        Assert.Null(_orderRepository.GetSavedOrder());
    }

    [Fact]
    public void CannotRejectApprovedOrder()
    {
        var initialOrder = new Order
        {
            State = new ApprovedState(),
            Id = 1
        };
        _orderRepository.AddOrder(initialOrder);

        var request = new OrderApprovalRequest
        {
            OrderId = 1,
            Approved = false
        };


        Action actionToTest = () => _useCase.Run(request);

        Assert.Throws<ApprovedOrderCannotBeRejectedException>(actionToTest);
        Assert.Null(_orderRepository.GetSavedOrder());
    }

    [Fact]
    public void ShippedOrdersCannotBeRejected()
    {
        var initialOrder = new Order
        {
            State = new ShippedState(),
            Id = 1
        };
        _orderRepository.AddOrder(initialOrder);

        var request = new OrderApprovalRequest
        {
            OrderId = 1,
            Approved = false
        };


        Action actionToTest = () => _useCase.Run(request);

        Assert.Throws<ShippedOrdersCannotBeChangedException>(actionToTest);
        Assert.Null(_orderRepository.GetSavedOrder());
    }
}
