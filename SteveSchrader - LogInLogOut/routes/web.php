<?php

use App\Http\Controllers\AdminController;
use App\Http\Controllers\Auth\LoginController;
use Dotenv\Validator;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\Redirect;
use Illuminate\Support\Facades\Route;
use Symfony\Component\Console\Input\Input;

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

/* LOG-IN */
Route::view('/', 'api.login');
Route::post('login', [LoginController::class, 'login'])->name('login');

Route::middleware(['auth:sanctum', 'verified'])->group(function () {
   Route::get('welcome', [AdminController::class, 'welcome'])->name('welcome');
});

/* ADMINISTRATOR FUNCTIONS */
Route::prefix('/admin')->middleware(['auth:sanctum', 'verified'])->group(function () {
    Route::post('/register', [AdminController::class, 'create'])->name('user.register');
    Route::get('/modify/{id}', [AdminController::class, 'edit'])->name('user.edit');
    Route::put('/modify/{id}', [AdminController::class, 'update'])->name('user.update');
    Route::get('/remove/{id}', [AdminController::class, 'delete'])->name('user.delete');
    Route::delete('/remove/{id}', [AdminController::class, 'destroy'])->name('user.delist');
});

Auth::routes([
    'login'    => false,
    'logout'   => true,
    'register' => false,
    'reset'    => false,
    'confirm'  => false,
    'verify'   => false,
]);
