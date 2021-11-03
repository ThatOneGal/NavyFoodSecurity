<?php

use App\Http\Controllers\LocationController;
use App\Http\Controllers\OrderController;
use App\Http\Controllers\StatusController;
use App\Http\Controllers\UserRolesController;
use Illuminate\Support\Facades\Route;

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
    return view('auth.login');
});

Route::middleware(['auth:sanctum', 'verified'])->group(function () {

    Route::resource('Order', OrderController::class);
    Route::resource('Location', LocationController::class);
    Route::resource('Status', StatusController::class);
    Route::resource('UserRole', UserRolesController::class);


    Route::get('/dashboard', function (){
        return view('dashboard');

    })->name('dashboard');


    Route::get('/LastOrder', [OrderController::class, 'last']);

    Route::get('/showID/', [OrderController::class, 'showByID'])->name('showById');
});

