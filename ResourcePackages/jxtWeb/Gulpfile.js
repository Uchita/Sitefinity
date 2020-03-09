'use strict';

const { src, dest, parallel, watch, series } = require('gulp');
const sass = require('gulp-sass');
sass.compiler = require('node-sass');
const sourcemaps = require('gulp-sourcemaps');
const mq = require('gulp-merge-media-queries');
const sassdoc = require('sassdoc');
const fs = require('fs');
const pkg = JSON.parse(fs.readFileSync('./package.json'));
const minify = require('gulp-minify');
const bS = require('browser-sync').create();
const clean = require('gulp-clean');

const sassOpts = {
    outputStyle: 'expanded'
};
const sassOptsProd = {
    outputStyle: 'compressed'
};
const proDirs = {
    sass: pkg.config.styleSrc,
    css: pkg.config.styleDist,
    js: pkg.config.jsSrc
};
const sassdocOptions = {
    dest: pkg.config.sassdocDir
};
const minifyOpt = {
    ext: {
        min: '.min.js'
    }
};

function cssDev() {
    return src(proDirs.sass + '/*.scss')
        .pipe(sourcemaps.init())
        .pipe(sass(sassOpts).on('error', sass.logError))
        .pipe(sourcemaps.write('./css-maps/'))
        .pipe(dest(proDirs.css))
        .pipe(bS.stream());
}

function cssProd() {
    return src(proDirs.sass + '/*.scss')
        .pipe(sass(sassOptsProd).on('error', sass.logError))
        .pipe(mq({ log: true }))
        .pipe(dest(proDirs.css));
}

function akWatch() {
    return watch(proDirs.sass + '/**/*.scss', cssDev);
}

function sassDoc() {
    return src(proDirs.sass + '/**/*.scss')
        .pipe(sassdoc(sassdocOptions))
        .resume();
}

function js() {
    return src(pkg.config.jsSrc)
        .pipe(minify(minifyOpt))
        .pipe(dest(pkg.config.jsDist));
}
function jsWatch() {
    return watch(proDirs.js, js);
}
function copyFonts() {
    return src(pkg.config.fontSrc)
        .pipe(dest(pkg.config.fontDist));
}

function images() {
    return src(pkg.config.imageSrc)
        .pipe(dest(pkg.config.imageDist));
}

function server(cb) {
    bS.init({
        server: { baseDir: "./", routes: { "/": "Docs" } },
        port: 3020,
        ui: {
            port: 3021
        },
        open: true,
        notify: false
    });
    akWatch();
    jsWatch();
    cb();
}
function serverSite(cb) {
    bS.init({
        proxy: "localhost:60876"
    });
    akWatch();
    jsWatch();
    cb();
}

function cleanDist() {
    return src(pkg.config.dist, { read: false }).pipe(clean());
}


//module.exports.js = js;
//module.exports.font = copyFonts;
//module.exports.images = images;
module.exports.watch = parallel(cssDev, akWatch, js, jsWatch);
module.exports.serve = series(cssDev, js, copyFonts, images, server);
module.exports.sitefinity = series(cssDev, js, copyFonts, images, serverSite);
module.exports.sassdoc = sassDoc;
module.exports.clean = cleanDist;
module.exports.default = series(cssDev, js, copyFonts, images);
module.exports.build = series(cleanDist, cssProd, js, copyFonts, images);