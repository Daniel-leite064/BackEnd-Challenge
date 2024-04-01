CREATE SCHEMA "challengedb"

CREATE TABLE "challengedb"."Notification" (
  "id" uuid PRIMARY KEY,
  "date_notification" date,
  "id_order" uuid,
  "id_courier" uuid
);

CREATE TABLE "challengedb"."Rental" (
  "id" uuid PRIMARY KEY,
  "id_motorcycle" uuid,
  "id_courier" uuid,
  "id_rental_plans" uuid,
  "start_date" date,
  "end_date" date,
  "expected_end_date" date,
  "total_cost" decimal,
  "status" varchar
);

CREATE TABLE "challengedb"."Motorcycle" (
  "id" uuid PRIMARY KEY,
  "year" int,
  "model" varchar,
  "license_plate" varchar UNIQUE
  "status" boolean
);

CREATE TABLE "challengedb"."Couriers" (
  "id" uuid PRIMARY KEY,
  "name" varchar,
  "cnpj" varchar UNIQUE,
  "date_birth" date,
  "license_driver_number" varchar UNIQUE,
  "license_driver_type" varchar
);

CREATE TABLE "challengedb"."Rental_Plan" (
  "id" uuid PRIMARY KEY,
  "plan" int UNIQUE,
  "description" varchar,
  "cost_per_day" decimal
);

CREATE TABLE "challengedb"."Orders" (
  "id" uuid PRIMARY KEY,
  "id_courier" uuid,
  "creation_date" date,
  "ride_cost" decimal,
  "status" varchar
);

ALTER TABLE "challengedb"."Rental" ADD CONSTRAINT "fk_motorcycles_rentals" FOREIGN KEY ("id_motorcycle") REFERENCES "challengedb"."Motorcycle" ("id");

ALTER TABLE "challengedb"."Rental" ADD CONSTRAINT "fk_couriers_rentals" FOREIGN KEY ("id_courier") REFERENCES "challengedb"."Couriers" ("id");

ALTER TABLE "challengedb"."Rental" ADD CONSTRAINT "fk_rental_plans_rentals" FOREIGN KEY ("id_rental_plans") REFERENCES "challengedb"."Rental_Plan" ("id");

ALTER TABLE "challengedb"."Orders" ADD FOREIGN KEY ("id_courier") REFERENCES "challengedb"."Couriers" ("id");

ALTER TABLE "challengedb"."Notification" ADD FOREIGN KEY ("id_courier") REFERENCES "challengedb"."Couriers" ("id");

ALTER TABLE "challengedb"."Notification" ADD FOREIGN KEY ("id_order") REFERENCES "challengedb"."Orders" ("id");
