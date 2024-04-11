CREATE TABLE appeal(
  id integer NOT NULL PRIMARY KEY,
  appeal_type varchar(255) NOT NULL
);

CREATE TABLE agile(
  id integer NOT NULL CONSTRAINT agile_pk PRIMARY KEY AUTOINCREMENT,
  description varchar(1000) NOT NULL,
  time_of_appeal datetime NOT NULL,
  appeal_deadline datetime NOT NULL,
  is_solved boolean NOT NULL,
  appeal_type_id int NOT NULL,
  FOREIGN KEY (appeal_type_id) REFERENCES appeal(id)
);

INSERT INTO appeal(id, 
appeal_type) VALUES(1,"Issue with product"), 
(2, "Customer service problem"),
(3, "Billing dispute"),
(4, "Delivery problem"),
(5, "Other");