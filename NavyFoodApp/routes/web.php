<?php

use App\Http\Controllers\LocationController;
use App\Http\Controllers\OrderController;
use App\Http\Controllers\StatusController;
use Illuminate\Support\Facades\Route;
use SimpleSoftwareIO\QrCode\Facades\QrCode;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Route::get('/', function () {
    return view('welcome');
});

Route::middleware(['auth:sanctum', 'verified'])->group(function () {

    Route::resource('order', OrderController::class);
    Route::resource('location', LocationController::class);
    Route::resource('status', StatusController::class);

    Route::get('/history', function () {
        return view('history.history');
    })->name('history');

    Route::get('/dashboard', function (){
        return view('dashboard');

    })->name('dashboard');


    Route::get('/LastOrder', [OrderController::class, 'last']);

    Route::post('/showID/{id}', [OrderController::class, 'showByID']);
});


;
