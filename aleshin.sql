use  aleshin;
create table students (id int primary key auto_increment ,name varchar(20) , surname varchar(20) , patronymic varchar(20) , image varchar(20));
insert into students (name , surname, patronymic , image) values('Aleksandr' , 'aleshin' ,'Ilich' , 'C:\Users\ab448\Downloads\aleshin.jpg');
create table student_info(id int primary key , group_student varchar(20), faculty varchar(20) , direction_of_study varchar(30)) ;
alter table student_info add foreign key(id) references students(id);
 