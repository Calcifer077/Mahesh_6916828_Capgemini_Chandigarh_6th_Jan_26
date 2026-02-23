
/* ** Insert values in table called LMS_MEMBERS ** */

Insert into LMS_MEMBERS
Values('LM001', 'AMIT', 'CHENNAI', to_date('12-02-2012','dd-mm-yyyy'), to_date('11-02-2013','dd-mm-yyyy'),'Temporary');

Insert into LMS_MEMBERS
Values('LM002', 'ABDHUL', 'DELHI', to_date('10-04-2012','dd-mm-yyyy'), to_date('09-04-2013','dd-mm-yyyy'),'Temporary');

Insert into LMS_MEMBERS
Values('LM003', 'GAYAN', 'CHENNAI', to_date('12-05-2013','dd-mm-yyyy'),to_date('14-05-2013','dd-mm-yyyy'), 'Permanent');

Insert into LMS_MEMBERS
Values('LM004', 'RADHA', 'CHENNAI', to_date('22-04-2012','dd-mm-yyyy'), to_date('21-04-2013','dd-mm-yyyy'), 'Temporary');

Insert into LMS_MEMBERS
Values('LM005', 'GURU', 'BANGALORE', to_date('30-03-2012','dd-mm-yyyy'), to_date('29-03-2013','dd-mm-yyyy'),'Temporary');

Insert into LMS_MEMBERS
Values('LM006', 'MOHAN', 'CHENNAI', to_date('12-04-2012','dd-mm-yyyy'), to_date('12-04-2013','dd-mm-yyyy'),'Temporary');








/* ** Insert values in table called LMS_SUPPLIERS_DETAILS ** */


Insert into  LMS_SUPPLIERS_DETAILS 
Values ('S01','SINGAPORE SHOPPEE', 'CHENNAI', 9894123555,'sing@gmail.com');

Insert into  LMS_SUPPLIERS_DETAILS 
Values ('S02','JK Stores', 'MUMBAI', 9940123450 ,'jks@yahoo.com');

Insert into  LMS_SUPPLIERS_DETAILS 
Values ('S03','ROSE BOOK STORE', 'TRIVANDRUM', 9444411222,'rose@gmail.com');

Insert into  LMS_SUPPLIERS_DETAILS 
Values ('S04','KAVARI STORE', 'DELHI', 8630001452,'kavi@redif.com');

Insert into  LMS_SUPPLIERS_DETAILS 
Values ('S05','EINSTEN BOOK GALLARY', 'US', 9542000001,'eingal@aol.com');

Insert into  LMS_SUPPLIERS_DETAILS 
Values ('S06','AKBAR STORE', 'MUMBAI',7855623100 ,'akbakst@aol.com');





/* ** Insert values in table called LMS_FINE_DETAILS ** */


Insert into LMS_FINE_DETAILS Values('R1', 20);

insert into LMS_FINE_DETAILS Values('R2', 50);

Insert into LMS_FINE_DETAILS Values('R3', 75);

Insert into LMS_FINE_DETAILS Values('R4', 100);

Insert into LMS_FINE_DETAILS Values('R5', 150);

Insert into LMS_FINE_DETAILS Values('R6', 200);

      


/* ** Insert values in table called LMS_BOOK_DETAILS ** */


Insert into LMS_BOOK_DETAILS
Values('BL000001', 'Java How To Do Program', 'JAVA', 'Paul J. Deitel', 'Prentice Hall', to_date('10-12-1999','dd-mm-yyyy'), 6, 600.00, 'A1', to_date('10-05-2011','dd-mm-yyyy'), 'S01');

Insert into LMS_BOOK_DETAILS
Values('BL000002', 'Java: The Complete Reference ', 'JAVA', 'Herbert Schildt',  'Tata Mcgraw Hill ', to_date('10-10-2011','dd-mm-yyyy'), 5, 750.00, 'A1', to_date('10-05-2011','dd-mm-yyyy'), 'S03');

Insert into LMS_BOOK_DETAILS 
Values('BL000003', 'Java How To Do Program', 'JAVA', 'Paul J. Deitel', 'Prentice Hall', to_date('10-12-1999','dd-mm-yyyy'), 6, 600.00, 'A1', to_date('12-05-2012','dd-mm-yyyy'), 'S01');

Insert into LMS_BOOK_DETAILS
Values('BL000004', 'Java: The Complete Reference ', 'JAVA', 'Herbert Schildt', 'Tata Mcgraw Hill ', to_date('10-10-2011','dd-mm-yyyy'), 5, 750.00, 'A1', to_date('12-05-2012','dd-mm-yyyy'), 'S01');

Insert into LMS_BOOK_DETAILS 
Values('BL000005', 'Java How To Do Program', 'JAVA', 'Paul J. Deitel',  'Prentice Hall', to_date('10-12-1999','dd-mm-yyyy'), 6, 600.00, 'A1', to_date('12-05-2012','dd-mm-yyyy'), 'S01');

Insert into LMS_BOOK_DETAILS
Values('BL000006', 'Java: The Complete Reference ', 'JAVA', 'Herbert Schildt', 'Tata Mcgraw Hill ', to_date('10-10-2011','dd-mm-yyyy'), 5, 750.00, 'A1', to_date('12-05-2012','dd-mm-yyyy'), 'S03');

Insert into LMS_BOOK_DETAILS 
Values('BL000007', 'Let Us C', 'C', 'Yashavant Kanetkar ', 'BPB Publications', to_date('11-12-2010','dd-mm-yyyy'),  9, 500.00 , 'A3', to_date('03-01-2010','dd-mm-yyyy'), 'S03');

Insert into LMS_BOOK_DETAILS 
Values('BL000008', 'Let Us C', 'C', 'Yashavant Kanetkar ','BPB Publications', to_date('11-12-2010','dd-mm-yyyy'),  9, 500.00 , 'A3', to_date('03-01-2010','dd-mm-yyyy'), 'S04');

       

/* ** Insert values in table called LMS_BOOK_ISSUE ** */


Insert into LMS_BOOK_ISSUE 
Values (001, 'LM001', 'BL000001', to_date('01-05-2012','dd-mm-yyyy'), to_date('16-05-2012','dd-mm-yyyy'), to_date('16-05-2012','dd-mm-yyyy'),'N', 'R1');

Insert into LMS_BOOK_ISSUE 
Values (002, 'LM002', 'BL000002', to_date('20-04-2012','dd-mm-yyyy'), to_date('06-05-2012','dd-mm-yyyy'),to_date('04-05-2012','dd-mm-yyyy'), 'N', 'R2');

Insert into LMS_BOOK_ISSUE
Values (003, 'LM003', 'BL000007', to_date('01-04-2012','dd-mm-yyyy'), to_date('16-04-2012','dd-mm-yyyy'), to_date('20-04-2012','dd-mm-yyyy'),'Y','R1');

Insert into LMS_BOOK_ISSUE 
Values (004, 'LM004', 'BL000005', to_date('01-04-2012','dd-mm-yyyy'), to_date('16-04-2012','dd-mm-yyyy'),to_date('20-04-2012','dd-mm-yyyy'), 'Y', 'R1');

Insert into LMS_BOOK_ISSUE 
Values (005, 'LM005', 'BL000008', to_date('30-03-2012','dd-mm-yyyy'), to_date('15-04-2012','dd-mm-yyyy'),to_date('20-04-2012','dd-mm-yyyy') ,'N', 'R2');






--question1--
--khiuhhk
kjjkjk
--theata style
select e.empid,e.ename,d.did,d.dname
from emptb e ,depttb d
where e.did=d.did
order by e.ename
--anis style
select e.empid,e.ename,d.did,d.dname
from emptb e join deptb d
on e.did=d.did
join table3
on d.did=t3.table3
join table4
on t4.pk=t3.pk

where e.ename='k%'
order by e.ename
