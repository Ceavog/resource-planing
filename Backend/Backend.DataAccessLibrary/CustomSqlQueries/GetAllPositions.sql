select Orders.*, MenuPositions.Id as MenuPositionId, MenuPositions.Name, MenuPositions.Section from Orders
inner join OrderPositions on Orders.Id = OrderPositions.OrderId inner join MenuPositions on OrderPositions.MenuPositionId = MenuPositions.Id
where condition;