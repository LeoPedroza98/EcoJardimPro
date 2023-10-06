<template>
  <master-page titulo="Home" icone="mdi-home">
    <v-card height="700">
      <v-card-text>
        <router-view></router-view>
      </v-card-text>
    </v-card>
  </master-page>
</template>

<script setup lang="ts">
</script>
<style lang="scss">
  @import url('https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700');

  html, body {
    font-family: 'Poppins', sans-serif;
  }

  #app {
    font-family: 'Poppins', sans-serif;
  }

  .v-pagination{
    .v-pagination__navigation{
      box-shadow: none !important;
    }
    .v-pagination__item{
      box-shadow: none;
    }
  }

  .v-card{
    border-radius: 10px !important;
  }

  .headerImg{
    position: absolute !important ;
    top: 0 ;
    left: 0 ;
    right: 0 ;
    z-index: 0 ;
    background-color: #1E1E2D ;
    box-shadow: none ;
    height: 280px ;
    border-bottom: 0 ;
    padding: 0 ;
  }

  .pageHeader{
    width: 90%;
    height: 80px;
    position: absolute;
    top: 0;
    left: 50%;
    transform: translateX(-50%);
    display: flex;
    align-items: center;

    .menuButton{
      .v-icon{
        font-size: 32px !important;
      }
    }

    .empresaLogo{
      width: 72px;
      height: 72px;
      margin-left: 10px;
    }

    .actions{
      position: absolute;
      width: 100%;
      height: 80px;
      position: absolute;
      top: 80px;
      left: 50%;
      transform: translateX(-50%);
      display: flex;
      align-items: center;
    }
  }

  .pageContent{
    width: 90%;
    position: relative;
    top: 170px;
    left: 50%;
    transform: translateX(-50%);
  }

  .btn-round{
    outline: none !important;
    box-shadow: none !important;
    color: var(--v-primary-base) !important;
    border-radius: 50% !important;
    height: 36px !important;
    width: 36px !important;
    .v-icon{
      font-size: 20px !important;
    }
  }

  .btn{
    min-width: 145px !important;
    outline: none !important;
    box-shadow: none !important;
    padding: 10px 15px 10px 15px !important;
    color: var(--v-primary-base) !important;
    border-radius: 6px !important;
    display: flex !important;
    justify-content: center !important;
    align-items: center !important;
    font-size: 12px !important;
    .v-icon {
      font-size: 20px !important;
      margin-right: 5px !important;
    }
  }

  .btn-primary{
    color: white !important;
    background-color: var(--v-primary-base) !important;
  }

  .listHeader{
    padding: 32px !important;
  }

  .table{
    width: 100%;

    thead{

      tr{
        .text-start{
          text-transform: uppercase ;
          font-weight: bold;
        }
      }
    }

    & > :not(:first-child) {
    	border-color: transparent;
      border-width: 0;
      border-style: none;
    }
    >:not(:last-child)>:last-child>* {
      border-bottom-color: inherit;
    }
    tr, th, td {
      border-color: inherit;
      border-width: inherit;
      border-style: dashed !important;
      text-transform: inherit;
      font-weight: inherit;
      font-size: inherit;
      color: inherit;
      height: inherit;
      min-height: inherit;
      .v-icon{
        font-size: 18px !important;
      }
    }
    tfoot,
    tbody {
      tr:last-child {
        border-bottom: 0 !important;

        th, td {
          border-bottom: 0 !important;
        }
      }
    }
    tfoot {
      th, td {
        border-top: inherit;
      }
    }
  }

  .dialogHeader{
    .v-toolbar{
      div{
        .v-btn{
          font-size: 16px;
          .v-icon{
            font-size: 26px;
          }
        }
      }
    }
  }

  @media screen and (max-width: 1400px){
    .pageHeader{
      width: 95% !important;
    }
    .pageContent{
      width: 95% !important;
    } 
    .btn{
      padding: 8px 8px 8px 8px !important;
      min-width: 120px !important;
      font-size: 12px !important;
      .v-icon{
        font-size: 20px !important;
        margin-right: 5px !important;
      }
    }
    .listHeader{
      padding: 22px !important;
    }
  }

  @media screen and (max-width: 992px){
    .headerImg{
      height: 230px;
    }
    .btn{
      padding: 10px 15px 10px 15px !important;
      min-width: 120px !important;
      font-size: 10px !important;
      .v-icon{
        font-size: 20px !important;
        margin-right: 5px !important;
      }
    }
    .pageHeader{
      width: 95% !important;
      height: 65px;
      .menuButton{
        .v-icon{
          font-size: 26px !important;
        }
      }
      .actions{
        height: 85px;
        top: 65px;
      }
      .empresaLogo{
        width: 55px;
        height: 55px;
      }
    }
    .pageContent{
      width: 98% !important;
      top: 150px;
    }
    .listHeader{
      padding: 15px 10px 15px 10px !important;
    }
  }

  @media screen and (max-width: 600px){
    .btn{
      min-width: 125px !important;
      font-size: 10px !important;
      .v-icon{
        font-size: 16px !important;
      }
    }
    .searchList{
      font-size: 14px !important;
      .v-label{
        font-size: 14px;
      }
    }
    .menuEmpresaLogo{
      img{
        max-width: 100px !important;
      }
    }
  }

</style>