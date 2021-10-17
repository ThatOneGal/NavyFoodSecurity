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

Route::resource('Orders','app\Http\Controllers\Api\OrderController');
Route::resource('status','app\Http\Controllers\Api\StatusController');
Route::resource('location','app\Http\Controllers\Api\LocationController');
Route::resource('Users','app\Http\Controllers\Api\UserController');
Route::resource('userrole', 'app\Http\Controllers\Api\UserRolesController');
