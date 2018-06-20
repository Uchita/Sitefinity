var gulp = require('gulp'),
    sass = require('gulp-sass'),
    sourcemaps = require('gulp-sourcemaps'),
    mq = require('gulp-merge-media-queries');
//var sassdoc = require('sassdoc');

var input = './assets/src/project/sass/**/*.scss',
    output = './assets/dist/css';

var sassOptions = {
    errLogToConsole: true,
    outputStyle: 'expanded'
  };

// var sassdocOptions = {
//     dest: './dist/sassdoc'
//   };

function style(){
  return gulp
    .src(input)
    // Initialize sourcemaps before compilation starts
    .pipe(sourcemaps.init())
    .pipe(sass(sassOptions).on('error', sass.logError))
    .pipe(mq({
        log: true
      }))
    // Now add/write the sourcemaps
    .pipe(sourcemaps.write())
    .pipe(gulp.dest(output));
}
function watch(){
  gulp.watch(input, style);
}


// gulp.task('sassdoc', function(){
//     return gulp
//     .src(input)
//     .pipe(sassdoc(sassdocOptions))
//     .resume();
// });

exports.watch = watch;