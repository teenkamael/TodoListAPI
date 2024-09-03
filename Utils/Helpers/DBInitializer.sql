
CREATE TABLE "Users"(
	id SERIAL NOT NULL,
	username varchar(255),
	password varchar(255),
	name varchar(255),
	surname varchar(255),
	email varchar(255),
	created_by VARCHAR(255),
	created_at TIMESTAMP,
	updated_by VARCHAR(255),
	updated_at TIMESTAMP,
	PRIMARY KEY("id")
);

CREATE TABLE "Status"(
	id SERIAL NOT NULL,
	name VARCHAR(255) NOT NULL,
	description VARCHAR,
	created_by VARCHAR(255),
	created_at TIMESTAMP,
	updated_by VARCHAR(255),
	updated_at TIMESTAMP,
	PRIMARY KEY(id)
);

CREATE TABLE "ItemTypes"(
	id SERIAL NOT NULL,
	name VARCHAR(255),
	description VARCHAR,
	created_by VARCHAR(255),
	created_at TIMESTAMP,
	updated_by VARCHAR(255),
	updated_at TIMESTAMP,
	 PRIMARY KEY(id)
);

CREATE TABLE "StatusItemTypes"(
	id SERIAL NOT NULL,
	status_id int,
	"itemType_id" int,
	enabled bool,
	created_by VARCHAR(255),
	created_at TIMESTAMP,
	updated_by VARCHAR(255),
	updated_at TIMESTAMP,
	PRIMARY KEY(id),
	CONSTRAINT fk_statusItemTypes_status
		FOREIGN KEY(status_id)
			REFERENCES "Status"(id)
			ON DELETE SET NULL,
	CONSTRAINT fk_statusItemTypes_itemTypes
		FOREIGN KEY("itemType_id")
			REFERENCES "ItemTypes"(id)
			ON DELETE SET NULL
);

CREATE SEQUENCE "StatusForTypes_id_seq"
START 1
INCREMENT 1
MINVALUE 1
OWNED BY "StatusItemTypes".id;

CREATE TABLE "Items"(
	id SERIAL NOT NULL ,
	name VARCHAR(255) NOT NULL,
	description VARCHAR,
	"itemType_id" int,
	status_id int,
	parent_item_id int,
	created_by VARCHAR(255),
	created_at TIMESTAMP,
	updated_by VARCHAR(255),
	updated_at TIMESTAMP,
	PRIMARY KEY(id),
	CONSTRAINT "fk_items_status"
		FOREIGN KEY(status_id)
			REFERENCES "Status"(id)
			ON DELETE SET NULL,
	CONSTRAINT "fk_items_itemTypes"
		FOREIGN KEY("itemType_id")
			REFERENCES "ItemTypes"(id)
			ON DELETE SET NULL,
	CONSTRAINT "fk_item_item"
		FOREIGN KEY("id")
			REFERENCES "Items"(id)
			ON DELETE SET NULL
);

INSERT INTO public."Status" ("name",description,created_by,created_at,updated_by,updated_at) VALUES
	 ('Pending','Marks state as not started','root','2024-08-31 01:34:40.401','root','2024-08-31 01:34:40.401'),
	 ('Active','Marks state as started but not finished','root','2024-09-02 01:35:04.6','root','2024-09-02 01:35:04.6'),
	 ('Done','Marks state as finished','root','2024-09-02 01:35:04.6','root','2024-09-02 01:35:04.6');

	INSERT INTO public."ItemTypes" ("name",description,created_by,created_at,updated_by,updated_at) VALUES
	 ('Task','Used to explain a simple task','root','2024-09-02 04:02:11.153693','ApiUser','2024-09-02 04:02:11.153698'),
	 ('Story','Used to explain a big task that contains collection of type Task','root','2024-09-02 04:03:39.415283','ApiUser','2024-09-02 04:03:39.415288'),
	 ('Epic','Used to explain a big task that contains collection of Story','root','2024-09-02 04:03:56.819199','ApiUser','2024-09-02 04:03:56.819205');


INSERT INTO public."StatusItemTypes"
(id, status_id, "itemType_id", enabled, created_by, created_at, updated_by, updated_at)
VALUES(nextval('"StatusForTypes_id_seq"'::regclass), 1, 1, true, 'root', NOW(), 'root', NOW());
INSERT INTO public."StatusItemTypes"
(id, status_id, "itemType_id", enabled, created_by, created_at, updated_by, updated_at)
VALUES(nextval('"StatusForTypes_id_seq"'::regclass), 2, 1, true, 'root', NOW(), 'root', NOW());
INSERT INTO public."StatusItemTypes"
(id, status_id, "itemType_id", enabled, created_by, created_at, updated_by, updated_at)
VALUES(nextval('"StatusForTypes_id_seq"'::regclass), 3, 1, true, 'root', NOW(), 'root', NOW());

