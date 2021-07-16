CREATE PROCEDURE [dbo].[GetAllPlayerPositions]
AS
SELECT '' AS PositionCode, 'All positions' AS PositionFullTitle, 0 As Number
UNION
SELECT *
FROM PlayerPosition
ORDER By Number
