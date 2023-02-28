<script setup lang="ts">
import { Navigate } from '@/common/utilities'
import { useI18n } from 'vue-i18n'

defineProps<{
    name:string
    code:number | undefined
    description:string | undefined
    startDate: Date  
    endDate: Date
    thumbnailUrl:string | undefined
    conditionsUrl:string | undefined
    bannerUrl:string | undefined
    category: Category
}>()

</script>

<template>
    
    <q-card
        class="campaign-card shadow-1 text-left cursor-pointer"
        disabled
        square
        @onclick="Navigate({ 
          name: 'PurchaseRegistration',
          params: {
              campaignCode:code
          }
        })">
        <div class="quasar">
            <q-icon class="icon" name="upcoming"/>

            <q-tooltip class="tooltip" anchor="center right" self="center left" :offset="[5, 5]">
                <strong> Comming soon</strong>
            </q-tooltip>
        </div>
        <q-card-section horizontal>
            <q-card-section>
                <div class="text-h5 text-bold"> 
                    {{ name }}
                </div>
                
                <q-separator/>

                <div class="text-caption text-weight-medium">
                    {{ startDate.toDateString() }} to {{ endDate.toDateString() }}
                </div>

                <q-separator/>
                
                <div class="text-body1">
                    {{ description }}
                </div>
            </q-card-section>

            <!-- If thumbnail path is empty/null, don't show thumbnail -->
            <q-img
                v-if="thumbnailUrl"
                class="col-4"
                src="https://cdn.quasar.dev/img/parallax2.jpg"
            />
        </q-card-section>
    </q-card>
</template>

<style scoped lang="scss">
.campaign-card{
    background: #373737 !important;
    color:#fff;
    margin-top: 20px;
    transition-property: box-shadow, transform, black;
    transition-duration: 350ms;
    transition-timing-function: ease;
    box-shadow: 0px 2px 4px 0px rgba(0, 0, 0, 0.24);

    &:hover, :focus{
        background: #3e8e41 !important;
        color: #000 !important;
        box-shadow: 0px 8px 10px 1px rgba(0, 0, 0, 0.2);
        transform: translateY(-8px);
    }

    .quasar{
        width: 60px;

        .icon{
            padding: 15px;
            padding-bottom: 0px;
            font-size: 30px;
        }
    }
}
</style>
