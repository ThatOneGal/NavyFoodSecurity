<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

class CreateOrdersTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('orders', function (Blueprint $table) {
            $table->id()->autoIncrement();
            $table->foreignId('CustomerId')->constrained('users');
            $table->foreignId('PackerId')->constrained('users')->nullable();
            $table->foreignId('DriverId')->constrained('users')->nullable();
            $table->foreignId('LocationId')->constrained('locations');
            $table->foreignId('StatusId')->constrained('statuses');
            $table->dateTime('OrderDate')->nullable();
            $table->dateTime('OrderShipped')->nullable();
            $table->dateTime('OrderPacked')->nullable();
            $table->string('PackageQty')->nullable();
            $table->string('Content', 1000)->nullable();
            $table->string('NotesStorage', 1000)->nullable();
            $table->string('NotesPreparation', 1000)->nullable();

            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {

        Schema::dropIfExists('orders');
    }
}
