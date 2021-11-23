<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

Route::middleware('auth:sanctum')->get('/user', function (Request $request) {
    return $request->user();
});

Route::resource('Orders','App\Http\Controllers\api\OrderController');
Route::resource('Statuses','App\Http\Controllers\api\StatusController');
Route::resource('Locations','App\Http\Controllers\api\LocationController');
Route::resource('Users','App\Http\Controllers\api\UserController');
Route::resource('UserRoles', 'App\Http\Controllers\api\UserRolesController');
