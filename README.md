# ���������� �� �������
��� ������� ���������� ���������� nodejs � dotnet.

������ ���������� ����� ����������� ����������� launch-me.bat. ��� ���������� � ���� ������:
- ��������������� npm-������ (npm install)
- � ������� Webpack ���������� ����� � production-������ (webpack --mode production)
- ���������� � ����������� ���������� (dotnet run -c Release --environment="Production")

��� �������, ������� ����� ��������� �������. ��� ����� ���������� ������� � ���������� src/JustAnotherSimpleFormApplication.Web � ��������� �������:
��� Release:
npm install
npm run build:prod
dotnet run -c Release --environment="Production" 

��� Dev:
npm install
npm run build:dev
dotnet run