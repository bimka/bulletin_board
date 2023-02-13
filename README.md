# :newspaper: ����� ���������� :pushpin:    
__________________
���������� CRUD Minimal API, ��� ������������� ��.     

## API ����������    
��� ������������� ���������� ������������� ����������� ����������� � ��������� ��� �� ��������� ������. ��� ������������ ����������� Postman ��� curl �� ������ http://localhost:4000/.  

### Create    
����� ������� ������ ������������ ����������� ��������� �������:
```
curl --location --request GET 'http://localhost:4000/user/create' \   
--header 'Content-Type: application/json' \   
--data-raw '{"name":"{user_name}","email":"{user_email}", "birthDay": "{user_birtDay}"}
```
��� {user_name} - ��� ������������,    
{user_email} - �������� ���� ������������,    
{user_birtDay} - ���� �������� ������������ � ������� "YYYY-MM-DDTHH:MM:SS" (��������, "1967-06-27T00:00:00").    
### Read    
��� ��������� ������� ������ ������������� �����������:    
```    
curl http://localhost:4000/    
```    
���� ���������� ���������� �� ����������� ������������:
```    
curl http://localhost:4000/user/{user_id}    
```    
��� {user_id} - ���������� ����� ������������.    
### Update    
� ������, ���� ���������� �������� ���������� � ������������:    
```
curl --location --request PUT 'http://localhost:4000/user/{user_id}/update' \    
--header 'Content-Type: application/json' \    
--data-raw '{"name":"{user_name}","email":"{user_email}"}'    
```
��� �������������� �������� ������ ���� name � email. ������, ����� �������� ������ ���� �� �����.    
### Delete    
��� �������� ������������ ����������� �������:    
```
curl --location --request DELETE 'http://localhost:4000/user/{user_id}/delete' 
```