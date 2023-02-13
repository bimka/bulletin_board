# :newspaper: Доска объявлений :pushpin:    
__________________
Реализован CRUD Minimal API, без использования БД.     

## API приложения    
Для использования приложения рекомендуется клонировать репозиторий и запустить его на локальной машине. Для тестирования используйте Postman или curl по адресу http://localhost:4000/.  

### Create    
Чтобы создать нового пользователя используете следующую команду:
```
curl --location --request GET 'http://localhost:4000/user/create' \   
--header 'Content-Type: application/json' \   
--data-raw '{"name":"{user_name}","email":"{user_email}", "birthDay": "{user_birtDay}"}
```
где {user_name} - имя пользователя,    
{user_email} - почтовый ящик пользователя,    
{user_birtDay} - дата роджения пользователя в формате "YYYY-MM-DDTHH:MM:SS" (Например, "1967-06-27T00:00:00").    
### Read    
Для получения полного списка пользователей используйте:    
```    
curl http://localhost:4000/    
```    
Если необходима информация по конкретному полюзователю:
```    
curl http://localhost:4000/user/{user_id}    
```    
где {user_id} - уникальный номер нользователя.    
### Update    
В случае, если необходимо обновить информацию о пользователе:    
```
curl --location --request PUT 'http://localhost:4000/user/{user_id}/update' \    
--header 'Content-Type: application/json' \    
--data-raw '{"name":"{user_name}","email":"{user_email}"}'    
```
Для редактирования доступны только поля name и email. Причем, можно заменять только одно из полей.    
### Delete    
При удалении пользователя используете команду:    
```
curl --location --request DELETE 'http://localhost:4000/user/{user_id}/delete' 
```