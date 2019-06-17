var gulp = require('gulp');

gulp.task('default', function () {
   
    var postcss = require('gulp-postcss');
    var tailwindcss = require('tailwindcss');
 
    return gulp.src('resources/styles.scss')
        .pipe(postcss([
            tailwindcss('resources/tailwind.config.js')
        ]))
        .pipe(gulp.dest('src/'))
});